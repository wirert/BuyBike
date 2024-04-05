namespace BuyBike.Core.Services.Contracts
{
    using BuyBike.Core.Models.Category;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Category service
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Get all categories with subcategories
        /// </summary>
        /// <returns></returns>
        Task<ICollection<CategoryDto>> GetCategoriesAsync();

        /// <summary>
        /// Get Category id by name
        /// </summary>
        /// <param name="name">Category name</param>
        /// <returns>category identifier</returns>
        Task<int> GetIdByName(string name);
    }
}
