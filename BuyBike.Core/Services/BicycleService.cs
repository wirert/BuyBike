namespace BuyBike.Core.Services
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using BuyBike.Core.Models;
    using BuyBike.Core.Services.Contracts;
    using BuyBike.Infrastructure.Contracts;
    using BuyBike.Infrastructure.Data.Entities;
    using BuyBike.Core.Models.Bicycle;
    using Microsoft.AspNetCore.Mvc;
    using BuyBike.Core.Constants;

    /// <summary>
    /// Product Service
    /// </summary>
    public class BicycleService : IBicycleService
    {
        private readonly IRepository repo;

        public BicycleService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<BicycleDetailsDto> GetById(Guid id)
        {            
            var result =  await repo.AllReadonly<Bicycle>(b => b.IsActive && b.Id == id)
                .Select(b => new BicycleDetailsDto
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
                    TyreSize = b.TyreSize,
                    Description = b.Description,
                    Items = b.Items.Select(i => new ItemDto 
                    { 
                        Id = i.Id,
                        Size = i.Size.ToString()!,
                        Sku = i.Sku,
                        IsInStock = i.InStock > 0
                    }),
                    Specification = b.Specification,
                } ).FirstOrDefaultAsync();

            if (result == null)
            {
                throw new ArgumentException("Invalid bicycle identifier.");
            }
          
            return result;
        }

        public async Task<PagedProductDto<ProductDto>> GetAllAsync(GetAllQueryModel query)
        {
            int skipCount = (query.Page - 1) * query.ItemsPerPage;            

            Expression<Func<Bicycle, bool>> filterExpr = b => b.IsActive;
            string? categoryImageUrl = string.Empty;

            if (string.IsNullOrEmpty(query.Category) == false)
            {
                categoryImageUrl = await repo.AllReadonly<Category>(c => c.Name == query.Category).Select(c => c.ImageUrl).FirstOrDefaultAsync();

                if(categoryImageUrl == null)
                {
                    throw new ArgumentException("Invalid category.");
                }

                filterExpr = b => b.IsActive && b.Category.Name == query.Category;
            }
            else
            {
                categoryImageUrl = await repo.AllReadonly<Category>(c => c.Name == "Велосипеди").Select(c => c.ImageUrl).FirstOrDefaultAsync();
            }

            int totalCount = await repo.AllReadonly(filterExpr).CountAsync();

            if (totalCount == 0)
            {
                throw new FileNotFoundException("Няма продукти в тази категория.");
            }

            if (totalCount <= skipCount)
            {
                throw new ArgumentException("Incorrect page number.");
            }

            if (query.ItemsPerPage > totalCount)
            {
                query.ItemsPerPage = totalCount;
            }

            var result = new PagedProductDto<ProductDto>()
            {
                TotalProducts = totalCount,
                CategoryImageUrl = AppConstants.MinIo_EndPoint + categoryImageUrl!,
            };

            var data = repo.AllReadonly(filterExpr);

            data = SortData(data, query.OrderBy, query.Desc);

            result.Products = await data
                .Skip(skipCount)
                .Take(query.ItemsPerPage)
                .Select(b => new ProductDto
                {
                    Id = b.Id,
                    Name = $"{b.Category.Name} велосипед {b.Name} {b.TyreSize}\" {b.Color}",
                    Make = b.Make.Name,
                    ImageUrl = AppConstants.MinIo_EndPoint + b.ImageUrl,
                    Price = b.Price,
                    Color = b.Color,
                    Category = b.Category.Name,
                    DiscountPercent = b.Discount != null ? b.Discount.DiscountPercent : null,
                }).ToListAsync();

            return result;
        }

        private IQueryable<Bicycle> SortData(IQueryable<Bicycle> data, string orderBy, bool isDesc)
        {
            if (isDesc)
            {
                return orderBy switch
                {
                    "Discount" => data.Where(b => b.DiscountId != null).OrderByDescending(b => b.Discount!.DiscountPercent),
                    "Name" => data.OrderByDescending(b => b.Name),
                    "Make" => data.OrderByDescending(b => b.Make.Name),
                    _ => data.OrderByDescending(b => b.Price),
                };
            }
            else
            {
                return orderBy switch
                {
                    "Discount" => data.Where(b => b.DiscountId != null).OrderBy(b => b.Discount!.DiscountPercent),
                    "Name" => data.OrderBy(b => b.Name),
                    "Make" => data.OrderBy(b => b.Make.Name),
                    _ => data.OrderBy(b => b.Price),
                };
            }
        }
    }
}
