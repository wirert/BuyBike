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

        [Comment("Tyre size")]
        [Required]
        public double TyreSize { get; set; }
    }
}