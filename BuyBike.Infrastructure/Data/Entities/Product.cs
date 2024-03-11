namespace BuyBike.Infrastructure.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations;

    [Comment("Shop product model")]
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid();
            OrderProducts = new HashSet<OrderProduct>();
        }

        [Key]
        [Comment("Product primary key")]
        public Guid Id { get; set; }

        [Comment("Product price")]
        [Required]
        public decimal Price { get; set; }

        [Comment("Bicycle count in stock")]
        [Required]
        public int InStock { get; set; }

        [Comment("Soft delete boolean property")]
        public bool IsActive { get; set; } = true;

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
