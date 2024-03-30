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
        /// Get a set of bicyle models by type 
        /// </summary>
        /// <param name="page">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="orderBy">Order by text</param>
        /// <param name="isDesc">Is in descending order</param>
        /// <param name="bikeType">bicycle type or null (for all types)</param>
        /// <returns>Paged bicycle object with total models count and Collection of Bicycle model DTO</returns>
        Task<PagedProductDto<BicycleDto>> GetAllAsync(int page, int pageSize, string orderBy, bool isDesc, BikeType? bikeType);

        /// <summary>
        /// Get Bicycle by Id
        /// </summary>
        /// <param name="id">Bicycle Identifier</param>
        /// <returns>Bicycle Data Transfer Object with details</returns>
        Task<BicycleDetailsDto> GetById(Guid id);
    }
}
