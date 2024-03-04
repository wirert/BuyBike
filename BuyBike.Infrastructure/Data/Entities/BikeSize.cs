namespace BuyBike.Infrastructure.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BikeSize
    {
        [Comment("Primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Bicycle size")]
        [Required]
        [MaxLength(10)]
        public string Size { get; set; } = null!;

        public virtual ICollection<Bicycle> Bicycles { get; set; } = new HashSet<Bicycle>();
    }
}
