namespace BuyBike.Core.Models.Manufacturer
{
    public class ManufacutrerDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
