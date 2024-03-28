namespace BuyBike.Core.Models
{
    using System.Collections.Generic;

    public class PagedProductsDto
    {
        public int TotalProducts { get; set; }

        public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
