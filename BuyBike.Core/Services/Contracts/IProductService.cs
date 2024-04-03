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
        /// <returns>Paged products object with total models count and Collection of Product model DTO</returns>
        Task<PagedProductDto<ProductDto>> GetAllAsync(GetAllQueryModel query, string tableName);

        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="id">Part Identifier</param>
        /// <returns>Product Data Transfer Object with details</returns>
        Task<ProductDetailsDto> GetById(Guid id);
    }
}
