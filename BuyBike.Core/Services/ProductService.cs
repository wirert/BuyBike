namespace BuyBike.Core.Services
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using BuyBike.Core.Constants;
    using BuyBike.Core.Models;
    using BuyBike.Core.Services.Contracts;
    using BuyBike.Infrastructure.Contracts;
    using BuyBike.Infrastructure.Data.Entities;

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

        public async Task<PagedProductDto<ProductDto>> GetAllAsync(GetAllQueryModel query, string productType)
        {
            int skipCount = (query.Page - 1) * query.ItemsPerPage;

            Expression<Func<Product, bool>> filterExpr = BuildFilterExpr(query.Category, query.OrderBy, out Func<Product, bool> filterFunc);
           
            var productsTypeInfo = repo.AllReadonly<ProductType>(p => p.Name == productType)
                .Select(p => new 
                {
                    p.Id,
                    ImageUrl = p.ImageUrl ?? "",
                }).FirstOrDefault();

            var productCount = await repo.AllReadonly<Product>(p => p.TypeId == productsTypeInfo!.Id).CountAsync(filterExpr);

            if ( productCount == 0)
            {
                throw new FileNotFoundException("Няма намерени продукти.");
            }

            if (productCount <= skipCount)
            {
                throw new ArgumentException("Невалиден номер на страница.");
            }

            if (query.ItemsPerPage > productCount)
            {
                query.ItemsPerPage = productCount;
            }

            var result = new PagedProductDto<ProductDto>()
            {
                CategoryImageUrl = AppConstants.MinIo_EndPoint + productsTypeInfo.ImageUrl,
                TotalProducts = productCount
            };


            var data = repo.AllReadonly<Product>(p => p.TypeId == productsTypeInfo.Id).Where(filterExpr);

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

            return result;
        }

        private Expression<Func<Product, bool>> BuildFilterExpr(string? category, string orderBy, out Func<Product, bool> func)
        {

            
            if (string.IsNullOrEmpty(category))
            {
                if (orderBy == "Discount")
                {
                    func = p => p.IsActive && p.DiscountId != null;
                    return p => p.IsActive && p.DiscountId != null;
                }

                func = p => p.IsActive;
                return p => p.IsActive;
            }

            if (orderBy == "Discount")
            {
                func = p => p.IsActive && p.Category.Name.ToLower() == category && p.DiscountId != null;
                return p => p.IsActive && p.Category.Name.ToLower() == category && p.DiscountId != null;
            }

            func = p => p.IsActive && p.Category.Name.ToLower() == category;
            return p => p.IsActive && p.Category.Name.ToLower() == category;
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
