namespace BuyBike.Core.Models
{
    using System.Collections.Generic;

    public class PagedProductDto
    {
        public int ProductTypeId { get; set; }

        public int TotalProducts { get; set; }

        public string CategoryImageUrl { get; set; } = string.Empty;

        public IEnumerable<AttributeValuesDto> Attributes { get; set; } = new List<AttributeValuesDto>();

        public IEnumerable<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
