namespace BuyBike.Core.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Login data transfer object
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// User email
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        /// <summary>
        /// User login password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
