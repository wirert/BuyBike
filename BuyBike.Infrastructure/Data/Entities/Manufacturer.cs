namespace BuyBike.Infrastructure.Data.Entities
{
    using BuyBike.Infrastructure.Constants;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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

        public virtual ICollection<Model> Models { get; set; } = new HashSet<Model>();
    }
}
