namespace BuyBike.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.EntityFrameworkCore;

    using BuyBike.Infrastructure.Data.Entities.Enumerations;
    using BuyBike.Infrastructure.Constants;

    [Comment("Bicycle")]
    public class Bicycle: Product
    {           
        [Comment("Tyre size")]
        [Required]
        public double TyreSize { get; set; }

        [Comment("Frame's material")]
        [Required]
        public BikeMaterial Material { get; set; }

        [Comment("Brakes type")]
        [Required]
        public BikeBrakes Brakes { get; set; }

        [Comment("Suspention type")]
        [Required]
        [MaxLength(DataConstants.Bicycle.MaxSuspentionLength)]
        public string Suspention { get; set; } = null!;

        [Comment("Bicycle riding style")]
        [MaxLength(DataConstants.Bicycle.MaxStyleLength)]
        public string? Style { get; set; }
    }
}