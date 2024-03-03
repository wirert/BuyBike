namespace BuyBike.Infrastructure.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BicycleType
    {
        public BicycleType()
        {
            Id = Guid.NewGuid();
            Bicycles = new HashSet<Bicycle>();
        }

        [Key]
        public Guid Id { get; set; }

        [Comment("Bicycle type")]
        [Required]
        public string Type { get; set; } = null!;

        public virtual ICollection<Bicycle> Bicycles { get; set;}

        [Comment("Soft delete boolean property")]
        public bool IsActive { get; set; } = true;
    }
}
