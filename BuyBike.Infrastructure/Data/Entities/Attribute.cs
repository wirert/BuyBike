namespace BuyBike.Infrastructure.Data.Entities
{
    using BuyBike.Infrastructure.Constants;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Comment("EAV pattern attribute model")]
    public class Attribute
    {
        [Comment("Attribute Id")]
        [Key]
        public int Id { get; set; }

        [Comment("Attribute name")]
        [Required]
        [MaxLength(DataConstants.Attribute.MaxNameLength)]
        public string Name { get; set; } = null!;

        [Comment("Product property value type (default: string)")]
        [MaxLength(DataConstants.Attribute.MaxValueTypeLenght)]
        public string DataType { get; set; } = "string";

        [Comment("Product type category id")]
        [Required]
        public int ProductTypeId { get; set; }

        [ForeignKey(nameof(ProductTypeId))]
        public virtual Category ProductType { get; set; } = null!;

        public virtual ICollection<ProductAttributeValue> Values { get; set; } = new List<ProductAttributeValue>();
    }
}
