namespace BuyBike.Infrastructure.Data.Utils
{
    using System;
    using System.Linq.Expressions;

    using BuyBike.Infrastructure.Data.Entities;

    public static class ProductExtention
    {
        public static decimal GetDiscountedPrice(this Product p)
        {
            return p.DiscountId == null ? p.Price : (p.Price * (100 - p.Discount!.DiscountPercent) / 100);
        }

        public static Expression<Func<Product, decimal>> GetDiscountedPrice()
        {
            return p => p.DiscountId == null ? p.Price : (p.Price * (100 - p.Discount!.DiscountPercent) / 100);
        }
    }
}
