namespace BuyBike.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json.Linq;

    using BuyBike.Core.Models;
    using BuyBike.Core.Services.Contracts;
    using BuyBike.Infrastructure.Contracts;
    using BuyBike.Infrastructure.Data.Entities;
    using BuyBike.Infrastructure.Data.Entities.Enumerations;
    using BuyBike.Core.Models.Bicycle;
    using Newtonsoft.Json;

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

        public async Task<PagedProductDto<BicycleDto>> GetAllAsync(int page, int pageSize, string orderBy, bool isDesc, BikeType? bikeType)
        {
            int skipCount = (page - 1) * pageSize;

            if (skipCount < 0)
            {
                throw new ArgumentException("Incorrect page number or page size.");
            }

            Expression<Func<Bicycle, bool>> searchTerms = b => b.IsActive;

            if (bikeType != null)
            {
                searchTerms = b => b.IsActive && b.Category.Name == bikeType.ToString();
            }

            int totalCount = await repo.AllReadonly(searchTerms).CountAsync();

            if (totalCount <= skipCount)
            {
                throw new ArgumentException("Incorrect page number.");
            }

            if (pageSize > totalCount)
            {
                pageSize = totalCount;
            }

            var data = repo.AllReadonly(searchTerms)
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
                }).AsQueryable();

            var result = new PagedProductDto<BicycleDto>()
            {
                TotalProducts = totalCount,
                Products = await SortAndFetchData(data, orderBy, isDesc, skipCount, pageSize)
            };

            return result;
        }

        private async Task<ICollection<BicycleDto>> SortAndFetchData(IQueryable<BicycleDto> data, string orderBy, bool isDesc, int skipCount, int pageSize)
        {
            orderBy = orderBy.ToLower();

            if (isDesc)
            {
                if (orderBy == "price")
                    return await data
                        .OrderByDescending(m => m.Price)
                        .Skip(skipCount)
                        .Take(pageSize)
                        .ToListAsync();
                else if (orderBy == "manufacturer")
                    return await data
                       .OrderByDescending(m => m.Make)
                       .Skip(skipCount)
                       .Take(pageSize)
                       .ToListAsync();

                else if (orderBy == "name")
                    return await data
                       .OrderByDescending(m => m.Name)
                       .Skip(skipCount)
                       .Take(pageSize)
                       .ToListAsync();

                else
                    return await data
                    .OrderByDescending(m => m)
                    .Skip(skipCount)
                    .Take(pageSize)
                    .ToListAsync();

            }
            else
            {
                if (orderBy == "price")
                    return await data
                        .OrderBy(m => m.Price)
                        .Skip(skipCount)
                        .Take(pageSize)
                        .ToListAsync();
                else if (orderBy == "manufacturer")
                    return await data
                       .OrderBy(m => m.Make)
                       .Skip(skipCount)
                       .Take(pageSize)
                       .ToListAsync();
                else if (orderBy == "name")
                    return await data
                       .OrderBy(m => m.Name)
                       .Skip(skipCount)
                       .Take(pageSize)
                       .ToListAsync();
                else
                    return await data
                    .OrderBy(m => m)
                    .Skip(skipCount)
                    .Take(pageSize)
                    .ToListAsync();
            }
        }
    }
}
