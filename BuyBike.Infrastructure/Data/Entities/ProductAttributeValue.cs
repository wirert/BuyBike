namespace BuyBike.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductAttributeValue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AttributeId { get; set; }

        [ForeignKey(nameof(AttributeId))]
        public Attribute Attribute { get; set; } = null!;

        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;
    }
}
