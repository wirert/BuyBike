namespace BuyBike.Core.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using BuyBike.Core.Constants;
    using BuyBike.Core.Models;
    using BuyBike.Core.Services.Contracts;
    using BuyBike.Infrastructure.Contracts;
    using BuyBike.Infrastructure.Data.Entities;
    using System.Linq.Expressions;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        public ProductService(IRepository _repo)
        {
            repo = _repo;
        }


        public async Task<ProductDetailsDto> GetById(Guid id)
        {
            var result = await repo.AllReadonly<Product>(b => b.IsActive && b.Id == id)
                .Select(b => new ProductDetailsDto
                {
                    Name = b.Name,
                    Make = b.Make.Name,
                    MakeLogoUrl = AppConstants.MinIo_EndPoint + b.Make.LogoUrl,
                    ImageUrl = AppConstants.MinIo_EndPoint + b.ImageUrl,
                    Price = b.Price,
                    DiscountPercent = b.Discount != null ? b.Discount.DiscountPercent : null,
                    Color = b.Color,
                    Category = b.Category.Name,
                    Gender = b.Gender,
                    Description = b.Description,
                    Items = b.Items.Select(i => new ItemDto
                    {
                        Id = i.Id,
                        Size = i.Size.ToString()!,
                        Sku = i.Sku,
                        IsInStock = i.InStock > 0
                    }),
                    Specification = b.Specification,
                }).FirstOrDefaultAsync();

            if (result == null)
            {
                throw new ArgumentException("Invalid product identifier.");
            }

            return result;
        }

        public async Task<PagedProductDto<ProductDto>> GetAllAsync(GetAllQueryModel query)
        {
            int skipCount = (query.Page - 1) * query.ItemsPerPage;

            Expression<Func<Product, bool>> filterExpr = BuildFilterExpr(query.Category, query.OrderBy);

            string? categoryImageUrl = string.Empty;

            if (string.IsNullOrEmpty(query.Category) == false)
            {
                categoryImageUrl = await repo.AllReadonly<Category>(c => c.Name == query.Category).Take(1).Select(c => c.ImageUrl).FirstOrDefaultAsync();

                if (categoryImageUrl == null)
                {
                    throw new ArgumentException("Невалидна категория.");
                }
            }

            int totalCount = await repo.AllReadonly(filterExpr).CountAsync();

            if (totalCount == 0)
            {
                throw new FileNotFoundException("Няма намерени продукти.");
            }

            if (totalCount <= skipCount)
            {
                throw new ArgumentException("Невалиден номер на страница.");
            }

            if (query.ItemsPerPage > totalCount)
            {
                query.ItemsPerPage = totalCount;
            }

            var result = new PagedProductDto<ProductDto>()
            {
                TotalProducts = totalCount
            };

            var data = repo.AllReadonly(filterExpr);

            data = SortData(data, query.OrderBy, query.Desc);

            result.Products = await data
                .Skip(skipCount)
                .Take(query.ItemsPerPage)
                .Select(b => new ProductDto
                {
                    Id = b.Id,
                    Name = $"{b.Category.Name} {b.Make.Name} {b.Name} {b.Color ?? string.Empty}",
                    Make = b.Make.Name,
                    ImageUrl = AppConstants.MinIo_EndPoint + b.ImageUrl,
                    Price = b.Price,
                    Color = b.Color,
                    Category = b.Category.Name,
                    DiscountPercent = b.Discount != null ? b.Discount.DiscountPercent : null,
                }).ToListAsync();
            
            if (string.IsNullOrEmpty(categoryImageUrl) && result.Products.Any())
            {
                result.CategoryImageUrl = await repo
                    .AllReadonly<Category>(c => c.Name == result.Products.First().Category!)
                    .Take(1)
                    .Select(c => c.ParentCategory!.ImageUrl)
                    .FirstOrDefaultAsync() ?? "";
            }

            return result;
        }

        private Expression<Func<Product, bool>> BuildFilterExpr(string? category, string orderBy)
        {
            if (string.IsNullOrEmpty(category))
            {
                if (orderBy == "Discount")
                {
                    return p => p.IsActive && p.DiscountId != null;
                }

                return p => p.IsActive;
            }

            if (orderBy == "Discount")
            {
                return p => p.IsActive && p.Category.Name == category && p.DiscountId != null;
            }

            return p => p.IsActive && p.Category.Name == category;
        }

        private IQueryable<Product> SortData(IQueryable<Product> data, string orderBy, bool isDesc)
        {
            if (isDesc)
            {
                return orderBy switch
                {
                    "Discount" => data.OrderByDescending(p => p.Discount!.DiscountPercent),
                    "Name" => data.OrderByDescending(p => p.Name),
                    "Make" => data.OrderByDescending(p => p.Make.Name),
                    _ => data.OrderByDescending(p => p.Price),
                };
            }
            else
            {
                return orderBy switch
                {
                    "Discount" => data.OrderBy(p => p.Discount!.DiscountPercent),
                    "Name" => data.OrderBy(p => p.Name),
                    "Make" => data.OrderBy(p => p.Make.Name),
                    _ => data.OrderBy(p => p.Price),
                };
            }
        }

    }
}
