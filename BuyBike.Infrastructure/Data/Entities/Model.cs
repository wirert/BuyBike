namespace BuyBike.Infrastructure.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;

    using BuyBike.Infrastructure.Data.Entities.Enumerations;

    [Comment("Bicycle model")]
    [Index(nameof(Type), IsUnique = false)]
    public class Model
    {
        [Key]
        [Comment("Model primary key")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Bicycle model name")]
        [Required]
        [MaxLength(60)]
        public string Name { get; set; } = null!;

        [Comment("Model manufacturer id")]
        [Required]
        public Guid MakeId { get; set; }

        [ForeignKey(nameof(MakeId))]
        public virtual Manufacturer Make { get; set; } = null!;

        [Comment("Bicycle model Type (Enumeration)")]
        [Required]
        public BikeType Type { get; set; }

        [Comment("Model Image URL")]
        [Required]
        public string ImageUrl { get; set; } = null!;

        [Comment("Gender nullable")]
        public string? Gender { get; set; }

        [Comment("Tyre size")]
        [Required]
        public int TyreSize { get; set; }

        public virtual ICollection<Bicycle> Bicycles { get; set; } = new HashSet<Bicycle>();

        [Comment("Soft delete boolean property")]
        public bool IsActive { get; set; } = true;
    }
}
