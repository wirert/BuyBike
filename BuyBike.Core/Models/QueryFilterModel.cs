namespace BuyBike.Core.Models
{
    using System;
    using System.Collections.Generic;

    public class QueryFilterModel
    {
        public string[]? Makes { get; set; }

        public string[]? Attributes { get; set; } = null;

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public bool? InStock { get; set; }
    }
}
