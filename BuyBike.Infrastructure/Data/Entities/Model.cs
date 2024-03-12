namespace BuyBike.Infrastructure.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;

    using BuyBike.Infrastructure.Data.Entities.Enumerations;
    using BuyBike.Infrastructure.Constants;

    [Comment("Bicycle model")]
    [Index(nameof(Type), IsUnique = false)]
    public class Model
    {
        [Key]
        [Comment("Model primary key")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Bicycle model name")]
        [Required]
        [MaxLength(DataConstants.Model.MaxNameLength)]
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
        [MaxLength(DataConstants.Model.MaxImageUrlLength)]
        public string ImageUrl { get; set; } = null!;

        [Comment("Gender (Undefined by default)")]
        public Gender Gender { get; set; } = Gender.Undefined;

        [Comment("Tyre size")]
        [Required]
        public double TyreSize { get; set; }

        [Comment("Bicycle model color (optional)")]
        [MaxLength(DataConstants.Model.MaxColorLength)]
        public string? Color { get; set; }

        [Comment("Bicycle model description (optional")]
        [MaxLength(DataConstants.Model.MaxDescriptionLenght)]
        public string? Description { get; set; }

        public virtual ICollection<Bicycle> Bicycles { get; set; } = new HashSet<Bicycle>();

        [Comment("Soft delete boolean property")]
        public bool IsActive { get; set; } = true;
    }
}
