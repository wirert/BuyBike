namespace BuyBike.Infrastructure.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    using Microsoft.EntityFrameworkCore;

    using BuyBike.Infrastructure.Constants;

    public class Manufacturer
    {
        [Key]
        [Comment("Manufacturer primary key")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(DataConstants.Manufacturer.MaxNameLength)]
        [Comment("Manufacturer name")]
        public string Name { get; set; } = null!;

        [Comment("Soft delete boolean property")]
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
