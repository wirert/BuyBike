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

        public BicyclesService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<ICollection<BicycleModelDto>> GetAllModelsAsync(BikeType? bikeType)
        {
            Expression<Func<Model, bool>> searchTerms = m => m.IsActive;

            if (bikeType != null)
            {
                searchTerms = m => m.IsActive && m.Type == bikeType;
            }

            return await repo.AllReadonly(searchTerms)
                .Select(m => new BicycleModelDto
                {
                    Id = m.Id,
                    Model = m.Name,
                    Make = m.Make.Name,
                    ImageUrl = m.ImageUrl,
                    TyreSize = m.TyreSize,
                    Price = m.Bicycles.First().Price,
                    Color = m.Color

                }).ToListAsync();
        }

        public async Task<PagedBicyclesDto> GetPagedModelsAsync(int page, int pageSize, string orderBy, bool isDesc, BikeType? bikeType)
        {
            int skipCount = (page - 1) * pageSize;

            if (skipCount < 0)
            {
                throw new ArgumentException("Incorrect page number or page size.");
            }

            Expression<Func<Model, bool>> searchTerms = m => m.IsActive;

            if (bikeType != null)
            {
                searchTerms = m => m.IsActive && m.Type == bikeType;
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
                .Select(m => new BicycleModelDto
                {
                    Id = m.Id,
                    Model = m.Name,
                    Make = m.Make.Name,
                    ImageUrl = m.ImageUrl,
                    TyreSize = m.TyreSize,
                    Price = m.Bicycles.First().Price,
                    Color = m.Color

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
