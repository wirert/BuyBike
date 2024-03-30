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

    /// <summary>
    /// Product Service
    /// </summary>
    public class BicycleService : IBicycleService
    {
        private readonly IRepository repo;
        private const string ImgBaseUrl = @"http://localhost:9000/buy-bike/";

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
                    MakeLogoUrl = ImgBaseUrl + b.Make.LogoUrl,
                    ImageUrl = ImgBaseUrl + b.ImageUrl,
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

        public async Task<PagedProductDto<BicycleDto>> GetAllAsync(GetAllQueryModel query)
        {
            int skipCount = (query.Page - 1) * query.ItemsPerPage;            

            Expression<Func<Bicycle, bool>> filterExpr = b => b.IsActive;

            if (string.IsNullOrEmpty(query.Category) == false)
            {
                filterExpr = b => b.IsActive && b.Category.Name == query.Category;
            }

            int totalCount = await repo.AllReadonly(filterExpr).CountAsync();

            if (totalCount <= skipCount)
            {
                throw new ArgumentException("Incorrect page number.");
            }

            if (query.ItemsPerPage > totalCount)
            {
                query.ItemsPerPage = totalCount;
            }

            var result = new PagedProductDto<BicycleDto>()
            {
                TotalProducts = totalCount
            };

            var data = repo.AllReadonly(filterExpr);

            data = SortData(data, query.OrderBy, query.Desc);


            result.Products = await data
                .Skip(skipCount)
                .Take(query.ItemsPerPage)
                .Select(b => new BicycleDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Make = b.Make.Name,
                    ImageUrl = ImgBaseUrl + b.ImageUrl,
                    Price = b.Price,
                    Color = b.Color,
                    Category = b.Category.Name,
                    TyreSize = b.TyreSize,
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
