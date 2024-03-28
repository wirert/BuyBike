namespace BuyBike.Core.Models
{
    using System;

    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Make { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public double TyreSize { get; set; }

        public decimal Price { get; set; }

        public string? Color { get; set; }

        public string Type { get; set; } = null!;
    }
}
