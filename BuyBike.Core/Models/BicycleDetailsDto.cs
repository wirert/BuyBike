namespace BuyBike.Core.Models
{
    using BuyBike.Infrastructure.Constants;
    using BuyBike.Infrastructure.Data.Entities.Enumerations;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class BicycleDetailsDto
    {
        public decimal Price { get; set; }

        public int? DiscountPercent { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string Make { get; set; } = null!;

        public string MakeLogoUrl { get; set; } = string.Empty;

        public string? Color { get; set; }

        public Gender? Gender { get; set; }

        public string? Description { get; set; }

        public string Type { get; set; } = null!;

        public string Model { get; set; } = null!;

        public double TyreSize { get; set; }

        public IEnumerable<ItemDto> Items { get; set; } = new List<ItemDto>();

        public IEnumerable<AttributeDto> Attributes { get; set; } = new List<AttributeDto>();
    }
}
