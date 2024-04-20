namespace BuyBike.Infrastructure.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   
    using Microsoft.EntityFrameworkCore;

    using BuyBike.Infrastructure.Constants;

    [Comment("Properties for different types of products")]
    public class Attribute
    {
        [Comment("Attribute id")]
        [Key]
        public int Id { get; set; }

        [Comment("Attribute name")]
        [Required]
        [MaxLength(DataConstants.ProductAttribute.MaxNameLength)]
        public string Name { get; set; } = null!;

        [Comment("Attribute real data type")]
        [MaxLength(DataConstants.ProductAttribute.MaxDataTypeLength)]
        public string DataType { get; set; } = "string";

        [Required]
        public int ProductTypeId { get; set; }

        [ForeignKey(nameof(ProductTypeId))]
        public ProductType ProductType { get; set; } = null!;

        public virtual ICollection<ProductAttributeValue> AttributeValues { get; set; } = new List<ProductAttributeValue>();
    }
}
