namespace BuyBike.Infrastructure.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;

    using BuyBike.Infrastructure.Constants;
    using BuyBike.Infrastructure.Data.Entities.Enumerations;

    [Comment("Shop product model")]
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid();            
            Items = new List<Item>();
        }

        [Key]
        [Comment("Product primary key")]
        public Guid Id { get; set; }

        [Comment("Product name")]
        [Required]
        [MaxLength(DataConstants.Product.MaxNameLength)]
        public string Name { get; set; } = null!;

        [Comment("Product category identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;

        [Comment("Product price")]
        [Required]
        public decimal Price { get; set; }

        [Comment("Product discount id")]
        public int? DiscountId { get; set; }

        [ForeignKey(nameof(DiscountId))]
        public Discount? Discount { get; set; }

        [Comment("Model Image URL")]
        [Required]
        [MaxLength(DataConstants.Product.MaxImageUrlLength)]
        public string ImageUrl { get; set; } = null!;

        [Comment("Product manufacturer id")]
        [Required]
        public Guid MakeId { get; set; }

        [ForeignKey(nameof(MakeId))]
        public virtual Manufacturer Make { get; set; } = null!;

        [Comment("Product color (optional)")]
        [MaxLength(DataConstants.Product.MaxColorLength)]
        public string? Color { get; set; }

        [Comment("Gender (optional)")]
        public Gender? Gender { get; set; }

        [Comment("Product description (optional")]
        [MaxLength(DataConstants.Product.MaxDescriptionLenght)]
        public string? Description { get; set; }

        [Comment("Product specification")]
        [Column(TypeName = "jsonb")]
        public string? Specification { get; set; }

        [Comment("Soft delete boolean property")]
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Item> Items { get; set; }
    }
}
