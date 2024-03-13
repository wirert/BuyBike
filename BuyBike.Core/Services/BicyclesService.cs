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
    }
}
