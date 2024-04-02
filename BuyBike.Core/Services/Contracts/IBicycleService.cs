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
        /// <param name="query">Query parameters</param>        
        /// <returns>Paged bicycle object with total models count and Collection of Bicycle model DTO</returns>
        Task<PagedProductDto<ProductDto>> GetAllAsync(GetAllQueryModel query);

        /// <summary>
        /// Get Bicycle by Id
        /// </summary>
        /// <param name="id">Bicycle Identifier</param>
        /// <returns>Bicycle Data Transfer Object with details</returns>
        Task<BicycleDetailsDto> GetById(Guid id);
    }
}
