using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BuyBike.Infrastructure.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    [Comment("Bicycle")]
    public class Bicycle
    {
        public Bicycle()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [Comment("Bicycle primary key")]
        public Guid Id { get; set; }

        [Comment("Bicycle model name")]
        [Required]
        [MaxLength(60)]
        public string Model { get; set; } = null!;

        [Comment("Bicycle manufacturer id")]
        [Required]
        public Guid MakeId { get; set; }

        [ForeignKey(nameof(MakeId))]
        public virtual Manufacturer Make { get; set; } = null!;

        [Comment("Bicycle Type Id")]
        [Required]
        public Guid TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public virtual BicycleType Type { get; set; } = null!;

        [Comment("Bicycle price")]
        [Required]
        public decimal Price { get; set; }

        [Comment("Bicycle count in stock")]
        [Required]
        public int InStock { get; set; }

        public int MyProperty { get; set; }


        [Comment("Soft delete boolean property")]
        public bool IsActive { get; set; } = true;
    }
}
//    public material: string,
//    public sizes: number[],
//    public image: ImageData,
//    public color: string,
//    public gender?: string