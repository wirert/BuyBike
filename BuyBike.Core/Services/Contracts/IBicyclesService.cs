namespace BuyBike.Core.Services.Contracts
{
    using BuyBike.Core.Models;
    using BuyBike.Infrastructure.Contracts;
    using BuyBike.Infrastructure.Data.Entities;
    using BuyBike.Infrastructure.Data.Entities.Enumerations;

    /// <summary>
    /// Bicycles service
    /// </summary>
    public interface IBicyclesService
    {
        /// <summary>
        /// Gets all bicycles models by bicycle type or all models
        /// </summary>
        /// <param name="bikeType">Bicycle type(or null)</param>
        /// <returns>Collection of Bicycle DTO</returns>
        Task<ICollection<BicycleModelDto>> GetAllModelsAsync(BikeType? bikeType); 


    }
}
