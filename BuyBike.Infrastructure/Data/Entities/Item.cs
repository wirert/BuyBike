namespace BuyBike.Infrastructure.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    using Microsoft.EntityFrameworkCore;

    using BuyBike.Infrastructure.Constants;
    using BuyBike.Infrastructure.Data.Entities.Enumerations;

    [Comment("Product item for sale")]
    public class Item
    {
        public Item()
        {            
            ItemOrders = new List<OrderItem>();
        }

        [Comment("Item identifier")]
        [Key]
        public Guid Id { get; set; }

        [Comment("Product item number (SKU)")]
        [Required]
        [MaxLength(DataConstants.Product.ScuLenght)]
        public string Sku { get; set; } = null!;

        [Comment("Product items in stock")]
        [Required]
        public int InStock { get; set; }

        [Comment("Item size (enumeration")]
        public Size? Size { get; set; }

        [Comment("Soft delete property")]
        public bool IsActive { get; set; } = true;

        [Comment("Item's product identifier")]
        [Required]
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        public virtual ICollection<OrderItem> ItemOrders { get; set; }
    }
}
