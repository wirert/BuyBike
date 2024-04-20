namespace BuyBike.Core.Models
{
    using System.ComponentModel.DataAnnotations;

    using BuyBike.Core.Constants;
    using BuyBike.Infrastructure.Constants;

    public class AllProductQueryModel
    {
        [RegularExpression(AppConstants.ProductTypesPattern)]
        [Required]
        public string ProductType { get; set; } = null!;

        public string? Category { get; set; }

        //pagination
        [Range(1, 10000)]
        public int Page { get; set; } = 1;

        [Range(1, int.MaxValue)]
        public int ItemsPerPage { get; set; } = 12;

        [RegularExpression(AppConstants.QuerySortingValuesPattern)]
        public string OrderBy { get; set; } = AppConstants.QuerySortingDefaultValue;

        public bool Desc { get; set; }

        //filters
        public string? Makes { get; set; }

        public string? Attributes { get; set; } = null;

        [Range(typeof(decimal), DataConstants.Product.MinPrice, DataConstants.Product.MaxPrice)]
        public decimal MinPrice { get; set; } = decimal.Parse(DataConstants.Product.MinPrice);

        [Range(typeof(decimal), DataConstants.Product.MinPrice, DataConstants.Product.MaxPrice)]
        public decimal MaxPrice { get; set; } = decimal.Parse(DataConstants.Product.MaxPrice);

        public bool? InStock { get; set; }
    }
}
