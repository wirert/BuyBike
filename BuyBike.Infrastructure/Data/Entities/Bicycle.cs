namespace BuyBike.Infrastructure.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;

    using BuyBike.Infrastructure.Data.Entities.Enumerations;

    [Comment("Bicycle")]    
    public class Bicycle: Product
    {
        [Comment("Bicycle model Id")]
        [Required]        
        public Guid ModelId { get; set; }

        [ForeignKey(nameof(ModelId))]
        public virtual Model Model { get; set; } = null!;       

        [Comment("Bicycle frame size (enumeration)")]
        [Required]
        public BikeSize Size { get; set; }       
    }
}