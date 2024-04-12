namespace BuyBike.Core.Services.Contracts
{
    using BuyBike.Core.Models;

    /// <summary>
    /// Product service
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Get a set of products 
        /// </summary>
        /// <param name="query">Query parameters</param>        
        /// <param name="tableName">Product type</param>    
        /// <param name="filter">Products filter terms</param> 
        /// <returns>Paged products object with total models count and Collection of Product model DTO</returns>
        Task<PagedProductDto> GetAllAsync(GetAllQueryModel query, string tableName, QueryFilterModel? filter);

        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="id">Part Identifier</param>
        /// <returns>Product Data Transfer Object with details</returns>
        Task<ProductDetailsDto> GetById(Guid id);
    }
}
