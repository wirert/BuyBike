namespace BuyBike.Infrastructure.Constants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class MinIoConstants
    {
        public const string AccessPolicies = @"{
    ""Version"": ""2012-10-17"",
    ""Statement"": [
        {
            ""Effect"": ""Allow"",
            ""Principal"": {
                ""AWS"": [
                    ""*""
                ]
            },
            ""Action"": [
                ""s3:GetBucketLocation"",
                ""s3:ListBucket""
            ],
            ""Resource"": [
                ""arn:aws:s3:::buy-bike""
            ]
        },
        {
            ""Effect"": ""Allow"",
            ""Principal"": {
                ""AWS"": [
                    ""*""
                ]
            },
            ""Action"": [
                ""s3:GetObject""
            ],
            ""Resource"": [
                ""arn:aws:s3:::buy-bike/*""
            ]
        }
    ]
}";
    }
}
