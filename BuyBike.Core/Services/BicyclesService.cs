namespace BuyBike.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using BuyBike.Core.Models;
    using BuyBike.Core.Services.Contracts;
    using BuyBike.Infrastructure.Contracts;
    using BuyBike.Infrastructure.Data.Entities;
    using BuyBike.Infrastructure.Data.Entities.Enumerations;

    /// <summary>
    /// Bicycles Service
    /// </summary>
    public class BicyclesService : IBicyclesService
    {
        private readonly IRepository repo;
        private const string ImgBaseUrl = @"http://localhost:9000/buy-bike/";

        public BicyclesService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<ICollection<BicycleModelDto>> GetAllModelsAsync(BikeType? bikeType)
        {
            Expression<Func<Bicycle, bool>> searchTerms = b => b.IsActive;

            if (bikeType != null)
            {
                searchTerms = b => b.IsActive && b.Category.Name == bikeType.ToString();
            }

            return await repo.AllReadonly(searchTerms)
                .Select(b => new BicycleModelDto
                {
                    Id = b.Id,
                    Model = b.Model,
                    Make = b.Make.Name,
                    ImageUrl = ImgBaseUrl + b.ImageUrl,
                    TyreSize = b.TyreSize,
                    Price = b.Price,
                    Color = b.Color,
                    Type = b.Category.Name,

                }).ToListAsync();
        }

        public async Task<BicycleDetailsDto> GetById(Guid id)
        {            
            var result =  await repo.AllReadonly<Bicycle>(b => b.IsActive && b.Id == id)
                .Select(b => new BicycleDetailsDto
                {
                    Model = b.Model,
                    Make = b.Make.Name,
                    ImageUrl = ImgBaseUrl + b.ImageUrl,
                    TyreSize = b.TyreSize,
                    Price = b.Price,
                    DiscountPercent = b.Discount != null ? b.Discount.DiscountPercent : null,
                    Color = b.Color,
                    Type = b.Category.Name,
                    Gender = b.Gender,
                    Description = b.Description,
                    Items = b.Items.Select(i => new ItemDto 
                    { 
                        Id = i.Id,
                        Size = i.Size.ToString()!,
                        Sku = i.Sku,
                        IsInStock = i.InStock > 0
                    }),
                    Attributes = b.AttributeValues.Select(av => new AttributeDto
                    {
                        Name = av.Attribute.Name,
                        Value = av.Value
                    })
                } ).FirstOrDefaultAsync();


            if (result == null)
            {
                throw new ArgumentException("Invalid bicycle identifier.");
            }

            return result;
        }

        public async Task<PagedBicyclesDto> GetPagedModelsAsync(int page, int pageSize, string orderBy, bool isDesc, BikeType? bikeType)
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
                .Select(b => new BicycleModelDto
                {
                    Id = b.Id,
                    Model = b.Model,
                    Make = b.Make.Name,
                    ImageUrl = ImgBaseUrl + b.ImageUrl,
                    TyreSize = b.TyreSize,
                    Price = b.Price,
                    Color = b.Color,
                    Type = b.Category.Name,

                }).AsQueryable();

            var result = new PagedBicyclesDto()
            {
                TotalBicycles = totalCount,
                Bicycles = await SortAndFetchData(data, orderBy, isDesc, skipCount, pageSize)
            };

            return result;
        }

        private async Task<ICollection<BicycleModelDto>> SortAndFetchData(IQueryable<BicycleModelDto> data, string orderBy, bool isDesc, int skipCount, int pageSize)
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
                       .OrderByDescending(m => m.Model)
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
                       .OrderBy(m => m.Model)
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
