namespace BuyBike.Core.Models
{
    using System.Collections.Generic;

    public class PagedProductDto<T> where T : class
    {
        public int TotalProducts { get; set; }

        public ICollection<T> Products { get; set; } = new List<T>();
    }
}
