namespace BuyBike.Infrastructure.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Manufacturer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        [Comment("Soft delete boolean property")]
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Bicycle> Bicycles { get; set; } = new HashSet<Bicycle>();
    }
}
