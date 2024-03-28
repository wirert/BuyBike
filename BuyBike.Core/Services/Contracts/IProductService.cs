namespace BuyBike.Core.Services.Contracts
{
    using BuyBike.Core.Models;
    using BuyBike.Infrastructure.Contracts;
    using BuyBike.Infrastructure.Data.Entities;
    using BuyBike.Infrastructure.Data.Entities.Enumerations;

    /// <summary>
    /// Bicycles service
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all bicycles models by bicycle type or all models
        /// </summary>
        /// <param name="bikeType">Bicycle type(or null)</param>
        /// <returns>Collection of Bicycle DTO</returns>
        Task<ICollection<ProductDto>> GetAllModelsAsync(BikeType? bikeType);
                
        /// <summary>
        /// Get a set of bicyle models by type 
        /// </summary>
        /// <param name="page">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="orderBy">Order by text</param>
        /// <param name="isDesc">Is in descending order</param>
        /// <param name="bikeType">bicycle type or null (for all types)</param>
        /// <returns>Paged bicycle object with total models count and Collection of Bicycle model DTO</returns>
        Task<PagedProductsDto> GetPagedModelsAsync(int page, int pageSize, string orderBy, bool isDesc, BikeType? bikeType);

        /// <summary>
        /// Get Bicycle by Id
        /// </summary>
        /// <param name="id">Bicycle Identifier</param>
        /// <returns>Bicycle Data Transfer Object with details</returns>
        Task<ProductDetailsDto> GetById(Guid id);
    }
}
