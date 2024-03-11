namespace BuyBike.Infrastructure.Data.Entities
{
    using BuyBike.Infrastructure.Constants;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Application user entity model extention
    /// </summary>
    public class AppUser : IdentityUser<Guid>
    {
        [Comment("User First name")]
        [MaxLength(DataConstants.AppUser.MaxFirstNameLength)]
        public string? FirstName { get; set; }

        [Comment("User Last name")]
        [MaxLength(DataConstants.AppUser.MaxLastNameLength)]
        public string? LastName { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
