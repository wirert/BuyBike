namespace BuyBike.Infrastructure.Data.Entities
{
    using BuyBike.Infrastructure.Constants;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Comment("Optional attribute value table")]
    public class ProductAttributeValue
    {
        [Comment("Attribute identifier")]
        [Required]
        public int AttributeId { get; set; }

        [ForeignKey(nameof(AttributeId))]
        public Attribute Attribute { get; set; } = null!;

        [Comment("Attribute product identifier")]
        [Required]
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;

        [Comment("Attribute actual value")]
        [Required]
        [MaxLength(DataConstants.Attribute.MaxValueLenght)]
        public string Value { get; set; } = null!;
    }
}
