namespace BuyBike.Infrastructure.Data.Entities
{
    using BuyBike.Infrastructure.Constants;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    [Comment("Prodict discount")]
    public class Discount
    {
        [Comment("Discount identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Discount name")]
        [Required]
        [MaxLength(DataConstants.Discount.MaxNameLength)]
        public string Name { get; set; } = null!;


        [Comment("Discount description (optional)")]
        [MaxLength(DataConstants.Discount.MaxDescriptionLenght)]
        public string? Desc { get; set; }

        [Comment("Discount value - percentage")]
        [Required]
        public int DiscountPercent { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        [Comment("Soft delete boolean property")]
        public bool IsActive { get; set; } = true;

    }
}
