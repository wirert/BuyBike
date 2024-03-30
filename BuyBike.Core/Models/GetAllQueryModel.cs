namespace BuyBike.Core.Models
{
    using BuyBike.Core.Constants;
    using BuyBike.Core.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Query parameters model
    /// </summary>
    public class GetAllQueryModel
    {
        /// <summary>
        /// Product category
        /// </summary>
        public string? Category { get; set; }

        [Range(1, 10000)]
        public int Page { get; set; } = 1;

        [Range(1, int.MaxValue)]
        public int ItemsPerPage { get; set; } = 12;

        [AllowedValues("Price", "Name", "Discount", "Make")]
        public string OrderBy { get; set; } = AppConstants.QuerySortingDefaultValue;

        public bool Desc { get; set; }
    }
}
