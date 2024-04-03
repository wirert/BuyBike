﻿namespace BuyBike.Core.Constants
{
    public static class AppConstants
    {
        public static readonly string[] QuerySortingValues = ["Price", "Name", "Discount", "Make"];
        public const string QuerySortingDefaultValue = "Price";
        public const string MinIo_EndPoint = @"http://localhost:9000/buy-bike/";

        public static class ProductTypes
        {
            public const string Bicycles = "Велосипеди";
            public const string Parts = "Части";
            public const string Accessories = "Аксесоари";
            public const string Equipment = "Екипировка";
        }

       
    }
}
