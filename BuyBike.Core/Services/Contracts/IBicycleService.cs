namespace BuyBike.Core.Services.Contracts
{
    using BuyBike.Core.Models;
    using BuyBike.Core.Models.Bicycle;
    using BuyBike.Infrastructure.Data.Entities.Enumerations;

    /// <summary>
    /// Bicycles service
    /// </summary>
    public interface IBicycleService
    {   
        /// <summary>
        /// Get Bicycle by Id
        /// </summary>
        /// <param name="id">Bicycle Identifier</param>
        /// <returns>Bicycle Data Transfer Object with details</returns>
        Task<BicycleDetailsDto> GetById(Guid id);
    }
}
