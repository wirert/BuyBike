namespace BuyBike.Infrastructure.Data.Entities
{
    using BuyBike.Infrastructure.Constants;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.ProductCategory.MaxNameLength)]
        public string Name { get; set; } = null!;

        [Comment("Product description (optional")]
        [MaxLength(DataConstants.ProductCategory.MaxDescriptionLenght)]
        public string? Description { get; set; }

        public virtual ICollection<Attribute> Attributes { get; set; } = new List<Attribute>();

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
