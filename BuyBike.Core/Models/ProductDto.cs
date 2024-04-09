namespace BuyBike.Core.Models
{
    using BuyBike.Core.Models.Manufacturer;
    using System;

    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public ManufacutrerDto Make { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public string? Color { get; set; }

        public string Category { get; set; } = null!;

        public int? DiscountPercent { get; set; }

        public bool IsInStock { get; set; }
    }
}
