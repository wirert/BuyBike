namespace BuyBike.Infrastructure.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;

    using BuyBike.Infrastructure.Data.Entities.Enumerations;

    [Comment("Bicycle")]    
    public class Bicycle
    {
        [Key]
        [Comment("Bicycle primary key")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Bicycle model Id")]
        [Required]        
        public Guid ModelId { get; set; }

        [ForeignKey(nameof(ModelId))]
        public virtual Model Model { get; set; } = null!;

        [Comment("Bicycle price")]
        [Required]
        public decimal Price { get; set; }

        [Comment("Bicycle count in stock")]
        [Required]
        public int InStock { get; set; }

        [Comment("Bicycle frame size (enumeration)")]
        [Required]
        public BikeSize Size { get; set; }

        [Comment("Bicycle color (optional)")]
        public string? Color { get; set; }

        [Comment("Soft delete boolean property")]
        public bool IsActive { get; set; } = true;
    }
}
//    public material: string,
//    public sizes: number[],
//    public image: ImageData,
//    public color: string,
//    public gender?: string