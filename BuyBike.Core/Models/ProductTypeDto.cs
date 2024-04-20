namespace BuyBike.Core.Models
{
    using BuyBike.Core.Models.Category;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductTypeDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public IEnumerable<AttributeValuesDto> ProductsProperties { get; set; } = new List<AttributeValuesDto>();

        public IEnumerable<CategoryDto> Categories { get; set; } = Enumerable.Empty<CategoryDto>();
    }
}
