namespace BuyBike.Infrastructure.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;

    using BuyBike.Infrastructure.Constants;

    [Comment("Product property value table")]
    public class ProductAttributeValue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.ProductAttribute.MaxValueLength)]
        public string Value { get; set; } = null!;

        [Required]
        public int AttributeId { get; set; }

        [ForeignKey(nameof(AttributeId))]
        public Attribute Attribute { get; set; } = null!;

        [Required]
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
