namespace BuyBike.Infrastructure.Constants
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Models constants
    /// </summary>
    public static class DataConstants
    {
        /// <summary>
        /// Product image URL maximum length
        /// </summary>
        public const int MaxImageUrlLength = 1024;

        /// <summary>
        /// Product entity constants
        /// </summary>
        public static class Product
        {
            /// <summary>
            /// Product name maximum length
            /// </summary>
            public const int MaxNameLength = 60;
            /// <summary>
            /// Product name minimum length
            /// </summary>
            public const int MinNameLength = 1;

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

            public const string MinPrice = "0";
            public const string MaxPrice = "500000";
        }

        /// <summary>
        /// Product attribute constants
        /// </summary>
        public static class ProductAttribute
        {
            /// <summary>
            /// Product attribute name maximum length
            /// </summary>
            public const int MaxNameLength = 60;
            /// <summary>
            /// Product attribute name minimum length
            /// </summary>
            public const int MinNameLength = 1;

            /// <summary>
            /// Product attribute value maximum length
            /// </summary>
            public const int MaxValueLength = 40;

            /// <summary>
            /// Product attribute data type maximum length
            /// </summary>
            public const int MaxDataTypeLength = 8;
        }

        /// <summary>
        /// Bicycle entity constants 
        /// </summary>
        public static class Bicycle
        {            
            /// <summary>
            /// Suspention type maximum length
            /// </summary>
            public const int MaxSuspentionLength = 20;
            /// <summary>
            /// Suspention type minimum length
            /// </summary>
            public const int MinSuspentionLength = 1;

            /// <summary>
            /// Style maximum length
            /// </summary>
            public const int MaxStyleLength = 25;            
        }

        /// <summary>
        /// Product category constants 
        /// </summary>
        public static class Category
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
