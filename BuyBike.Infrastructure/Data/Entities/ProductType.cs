namespace BuyBike.Infrastructure.Data.Entities
{
    using BuyBike.Infrastructure.Constants;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [Comment("Product general type")]
    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        [Comment("Product type name")]
        [Required]
        public string Name { get; set; } = null!;

        [MaxLength(DataConstants.MaxImageUrlLength)]
        public string? ImageUrl { get; set; }

        [Comment("Product type description (optional")]
        [MaxLength(DataConstants.Category.MaxDescriptionLenght)]
        public string? Description { get; set; }

        public virtual IEnumerable<Product> Products { get; set; } = new List<Product>();

        public virtual ICollection<Category> Categories { get; set;} = new List<Category>();

        public virtual ICollection<Attribute> Properties { get; set; } = new List<Attribute>();
    }
}
