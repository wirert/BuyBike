namespace BuyBike.Infrastructure.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using BuyBike.Infrastructure.Constants;
    using Microsoft.EntityFrameworkCore;

    [Comment("User products order")]
    public class Order
    {
        [Comment("Order identifier")]
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Order user identifier")]
        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; } = null!;

        [Comment("Order time")]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Comment("Order shipping street address")]
        [Required]
        [StringLength(DataConstants.Order.MaxAddressLength)]
        public string Address { get; set; } = null!;

        [Comment("Order shipping zip code")]
        public int? ZipCode { get; set; }

        [Comment("Order delivery city")]
        [Required]
        [StringLength(DataConstants.Order.MaxCityLength)]
        public string City { get; set; } = null!;

        [Comment("Order delivery country")]
        [Required]
        [StringLength(DataConstants.Order.MaxCountryLength)]
        public string Country { get; set; } = null!;

        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
    }
}
