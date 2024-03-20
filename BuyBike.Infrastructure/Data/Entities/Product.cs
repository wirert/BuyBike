namespace BuyBike.Infrastructure.Data.Entities
{
    using BuyBike.Infrastructure.Constants;
    using BuyBike.Infrastructure.Data.Entities.Enumerations;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Comment("Shop product model")]
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid();            
            AttributeValues = new List<ProductAttributeValue>();
            Items = new List<Item>();
        }

        [Key]
        [Comment("Product primary key")]
        public Guid Id { get; set; }

        [Comment("Product price")]
        [Required]
        public decimal Price { get; set; }

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

        [Comment("Soft delete boolean property")]
        public bool IsActive { get; set; } = true;

        [Comment("Product category identifier")]
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual ProductCategory Category { get; set; } = null!;

        public virtual ICollection<ProductAttributeValue> AttributeValues { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
