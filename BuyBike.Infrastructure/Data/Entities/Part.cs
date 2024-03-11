namespace BuyBike.Infrastructure.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.EntityFrameworkCore;

    [Comment("Bicycle parts")]
    public class Part: Product
    {
        [Comment("Part name")]
        [Required]
        public string Name { get; set; } = null!;
    }
}
