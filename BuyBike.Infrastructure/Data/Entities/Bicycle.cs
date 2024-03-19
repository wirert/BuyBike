namespace BuyBike.Infrastructure.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.EntityFrameworkCore;

    using BuyBike.Infrastructure.Data.Entities.Enumerations;
    using BuyBike.Infrastructure.Constants;

    [Comment("Bicycle")]
    [Index(nameof(Model), IsUnique = false)]
    public class Bicycle: Product
    {
        [Comment("Bicycle model name")]
        [Required]
        [MaxLength(DataConstants.Bicycle.MaxNameLength)]
        public string Model { get; set; } = null!;

        [Comment("Bicycle frame size (enumeration)")]
        [Required]
        public BikeSize Size { get; set; }

        [Comment("Tyre size")]
        [Required]
        public double TyreSize { get; set; }
    }
}