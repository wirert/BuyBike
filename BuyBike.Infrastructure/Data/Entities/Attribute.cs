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
        //[MaxLength(DataConstants.Specification.MaxNameLength)]
        public string Name { get; set; } = null!;

        [Comment("Product property type (default: string)")]
        //[MaxLength(DataConstants.Specification.MaxDataTypeLength)]
        public string DataType { get; set; } = "string";

        [Required]
        public int ProductCategoryId { get; set; }

        [ForeignKey(nameof(ProductCategoryId))]
        public virtual ProductCategory ProductCategory { get; set; } = null!;

        public virtual ICollection<ProductAttributeValue> Values { get; set; } = new List<ProductAttributeValue>();
    }
}
