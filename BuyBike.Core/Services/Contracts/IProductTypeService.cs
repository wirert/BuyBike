namespace BuyBike.Core.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuyBike.Core.Models;

    /// <summary>
    /// Product type service
    /// </summary>
    public interface IProductTypeService
    {
        /// <summary>
        /// Get all product types with product categories and subcategories
        /// </summary>
        /// <returns></returns>
        Task<ICollection<ProductTypeDto>> GetAllAsync();
    }
}
