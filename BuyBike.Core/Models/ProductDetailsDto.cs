namespace BuyBike.Core.Models
{
    using BuyBike.Infrastructure.Data.Entities.Enumerations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class ProductDetailsDto
    {
        public decimal Price { get; set; }

        public int? DiscountPercent { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string Make { get; set; } = null!;

        public string MakeLogoUrl { get; set; } = string.Empty;

        public string? Color { get; set; }

        public Gender? Gender { get; set; }

        public string? Description { get; set; }

        public string Category { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Specification { get; set; }

        public IEnumerable<ItemDto> Items { get; set; } = new List<ItemDto>();
    }
}
