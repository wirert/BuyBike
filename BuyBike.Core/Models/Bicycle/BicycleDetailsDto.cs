namespace BuyBike.Core.Models.Bicycle
{
    using BuyBike.Infrastructure.Data.Entities.Enumerations;

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

        public string Category { get; set; } = null!;

        public string Name { get; set; } = null!;

        public double TyreSize { get; set; }

        public string? Specification { get; set; }

        public IEnumerable<ItemDto> Items { get; set; } = new List<ItemDto>();
    }
}
