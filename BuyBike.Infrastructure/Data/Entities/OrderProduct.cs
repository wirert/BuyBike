namespace BuyBike.Infrastructure.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Comment("Connecting table between orders and products")]
    public class OrderProduct
    {       
        [Comment("Product id")]
        [Required]
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [Comment("Order id")]
        [Required]
        public Guid OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [Comment("Product quantity")]
        public int Quantity { get; set; }
    }
}
