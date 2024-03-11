namespace BuyBike.Core.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    using static BuyBike.Infrastructure.Constants.DataConstants.AppUser;

    /// <summary>
    /// Register new user data transfere object
    /// </summary>
    public class RegisterDto
    {
        /// <summary>
        /// User Email (used for login Username)
        /// </summary>
        [Required]
        [EmailAddress]
        [RegularExpression(EmailRegExPattern)]
        public string Email { get; set; } = null!;

        /// <summary>
        /// User password
        /// </summary>
        [Required]
        [Compare(nameof(PasswordRepeat))]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        /// <summary>
        /// User confurm password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string PasswordRepeat { get; set; } = null!;

        /// <summary>
        /// User first name
        /// </summary>
        [Required]
        [StringLength(MaxFirstNameLength, MinimumLength = MinFirstNameLength)]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// User last name
        /// </summary>
        [Required]
        [StringLength(MaxLastNameLength, MinimumLength = MinLastNameLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [DataType(DataType.PhoneNumber)] 
        public string PhoneNumber { get; set;} = null!;        
    }
}
