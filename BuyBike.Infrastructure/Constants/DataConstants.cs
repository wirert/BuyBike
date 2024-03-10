namespace BuyBike.Infrastructure.Constants
{
    /// <summary>
    /// Models constants
    /// </summary>
    public static class DataConstants
    {
        /// <summary>
        /// Application user model constants
        /// </summary>
        public static class AppUser
        {
            /// <summary>
            /// Username maximum length
            /// </summary>
            public const int MaxUserNameLength = 15;
            /// <summary>
            /// Username minimum length
            /// </summary>
            public const int MinUserNameLength = 5;

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

        /// <summary>
        /// Bicycle Model model constants
        /// </summary>
        public static class Model
        {
            /// <summary>
            /// Model name maximum length
            /// </summary>
            public const int MaxNameLength = 60;
            /// <summary>
            /// Model name minimum length
            /// </summary>
            public const int MinNameLength = 1;

            /// <summary>
            /// Image URL maximum length
            /// </summary>
            public const int MaxImageUrlLength = 2048;            
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
    }
}
