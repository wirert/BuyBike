namespace BuyBike.Infrastructure.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.EntityFrameworkCore;

    using BuyBike.Infrastructure.Constants;
    using System.ComponentModel.DataAnnotations.Schema;

    [Comment("Product category")]
    public class Category
    {
        [Comment("Category identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Category name")]
        [Required]
        [MaxLength(DataConstants.Category.MaxNameLength)]
        public string Name { get; set; } = null!;

        [Comment("Category description (optional")]
        [MaxLength(DataConstants.Category.MaxDescriptionLenght)]
        public string? Description { get; set; }

        [MaxLength(DataConstants.MaxImageUrlLength)]
        public string? ImageUrl { get; set; }

        [Comment("Product parent category (If any) - self referencing foreign key")]
        public int? ParentCategoryId { get; set; }

        [ForeignKey(nameof(ParentCategoryId))]
        public Category? ParentCategory { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();
    }
}
