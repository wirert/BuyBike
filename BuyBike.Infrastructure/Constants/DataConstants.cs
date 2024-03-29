﻿namespace BuyBike.Infrastructure.Constants
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Models constants
    /// </summary>
    public static class DataConstants
    {
        /// <summary>
        /// Product model constants
        /// </summary>
        public static class Product
        {
            /// <summary>
            /// Product image URL maximum length
            /// </summary>
            public const int MaxImageUrlLength = 1024;

            /// <summary>
            /// Product color maximum length
            /// </summary>
            public const int MaxColorLength = 20;

            /// <summary>
            /// Product description maximum length
            /// </summary>
            public const int MaxDescriptionLenght = 2048;

            /// <summary>
            /// Item SCU lenght
            /// </summary>
            public const int ScuLenght = 10;            
        }

        /// <summary>
        /// Bicycle model constants
        /// </summary>
        public static class Bicycle
        {
            /// <summary>
            /// Model name maximum length
            /// </summary>
            public const int MaxNameLength = 60;
            /// <summary>
            /// Model name minimum length
            /// </summary>
            public const int MinNameLength = 1;
        }

        /// <summary>
        /// Product category constants 
        /// </summary>
        public static class ProductCategory
        {
            /// <summary>
            /// Category name maximum length
            /// </summary>
            public const int MaxNameLength = 30;
            /// <summary>
            /// Category name minimum length
            /// </summary>
            public const int MinNameLength = 3;

            /// <summary>
            /// Category description maximum length
            /// </summary>
            public const int MaxDescriptionLenght = 2048;
        }

        /// <summary>
        /// Product additional attribute (property) constants
        /// </summary>
        public static class Attribute
        {
            /// <summary>
            /// Attribute name maximum length
            /// </summary>
            public const int MaxNameLength = 20;
            /// <summary>
            /// Attribute name minimum length
            /// </summary>
            public const int MinNameLenght = 3;

            /// <summary>
            /// Attribute value max lenght
            /// </summary>
            public const int MaxValueLenght = 80;

            /// <summary>
            /// Attribute value type maximum lenght
            /// </summary>
            public const int MaxValueTypeLenght = 10;
        }

        /// <summary>
        /// Application user model constants
        /// </summary>
        public static class AppUser
        {
            /// <summary>
            /// First name maximum length
            /// </summary>
            public const int MaxFirstNameLength = 20;
            /// <summary>
            /// First name minimum length
            /// </summary>
            public const int MinFirstNameLength = 2;

            /// <summary>
            /// Last name maximum length
            /// </summary>
            public const int MaxLastNameLength = 20;
            /// <summary>
            /// Last name minimum length
            /// </summary>
            public const int MinLastNameLength = 2;

            public const string EmailRegExPattern = @"^("".*""|(?>[a-zA-Z0-9!#\$%&'\*\+\-\/=\?\^_`{}\|~]|\\.)+(?>\.(?>[a-zA-Z0-9!#\$%&'\*\+\-\/=\?\^_`{}\|~]|\\.)+)*)@([a-zA-Z0-9!#\$%&'\*\+\-\/=\?\^_`{}\|~]+(?>\.[a-zA-Z0-9!#\$%&'\*\+\-\/=\?\^_`{}\|~]+)*)$";
        }

        /// <summary>
        /// Manufacturer model constants
        /// </summary>
        public static class Manufacturer
        {
            /// <summary>
            /// Manufacturer name maximum length
            /// </summary>
            public const int MaxNameLength = 20;
            /// <summary>
            /// Manufacturer name minimum length
            /// </summary>
            public const int MinNameLength = 1;

            /// <summary>
            /// Manufacturer logo image URL maximum length
            /// </summary>
            public const int MaxLogoUrlLength = 1024;
        }

        /// <summary>
        /// Discount model constants
        /// </summary>
        public static class Discount
        {
            /// <summary>
            /// Discount name maximum length
            /// </summary>
            public const int MaxNameLength = 20;
            /// <summary>
            /// Discount name minimum length
            /// </summary>
            public const int MinNameLength = 1;

            /// <summary>
            /// Discount description maximum length
            /// </summary>
            public const int MaxDescriptionLenght = 128;
        }

        /// <summary>
        /// Order model constants
        /// </summary>
        public static class Order
        {
            /// <summary>
            /// Address maximum length
            /// </summary>
            public const int MaxAddressLength = 80;
            /// <summary>
            /// Address minimum length
            /// </summary>
            public const int MinAddressLength = 2;

            /// <summary>
            /// Country maximum length
            /// </summary>
            public const int MaxCountryLength = 60;
            /// <summary>
            /// Country minimum length
            /// </summary>
            public const int MinCountryLength = 2;

            /// <summary>
            /// City maximum length
            /// </summary>
            public const int MaxCityLength = 80;
            /// <summary>
            /// City minimum length
            /// </summary>
            public const int MinCityLength = 1;
        }
    }
}
