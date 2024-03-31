namespace BuyBike.Core.Models.Category
{
    using System.Collections.Generic;

    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public IEnumerable<CategoryDto> SubCategories { get; set; } = new List<CategoryDto>();
    }
}
