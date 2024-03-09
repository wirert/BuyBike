namespace BuyBike.Infrastructure.Data.Entities.Account
{
    using BuyBike.Infrastructure.Constants;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Application user entity model extention
    /// </summary>
    public class AppUser: IdentityUser<Guid>
    {
        [Comment("User First name")]
        [MaxLength(DataConstants.AppUser.MaxFirstNameLength)]
        public string? FirstName { get; set; }

        [Comment("User Last name")]
        [MaxLength(DataConstants.AppUser.MaxLastNameLength)]
        public string? LastName { get; set; }

        [Comment("User Address")]
        [MaxLength(DataConstants.AppUser.MaxAddressLength)]
        public string? Address { get; set; }

        [Comment("User Zip Code")]
        public int? ZipCode { get; set; }

        [Required]
        [MaxLength(DataConstants.AppUser.MaxCityLength)]
        public string City { get; set; } = null!;

        [Required]
        [MaxLength(DataConstants.AppUser.MaxCountryLength)]
        public string Country { get; set; } = null!;
    }
}
