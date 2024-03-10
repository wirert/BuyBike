namespace BuyBike.Infrastructure.Data
{
    using System;
    using System.Security.Claims;

    using Microsoft.AspNetCore.Http;

    using BuyBike.Infrastructure.Contracts;
    using BuyBike.Infrastructure.Constants;

    /// <summary>
    /// Extracts Claims information from ClaimsPrincipal via HttpContextAccessor 
    /// </summary>
    public class UserContext : IUserContext
    {
        private ClaimsPrincipal User;
        //private HttpContext httpContext;

        public UserContext(IHttpContextAccessor _ca)
        {
            //httpContext = _ca.HttpContext;
            User = _ca.HttpContext.User;
        }

        public string UserId
        {
            get
            {
                string userId = String.Empty;

                if (User != null && User.Claims != null && User.Claims.Count() > 0)
                {
                    var subClaim = User.Claims
                        .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

                    if (subClaim != null)
                    {
                        userId = subClaim.Value;
                    }
                }

                return userId;
            }
        }

        public string FullName
        {
            get
            {
                string fullName = String.Empty;

                if (User != null && User.Claims != null && User.Claims.Count() > 0)
                {
                    var fullNameClaim = User.Claims
                        .FirstOrDefault(c => c.Type == CustomClaimType.FullName);

                    fullName = fullNameClaim?.Value ?? String.Empty;
                }

                return fullName;
            }
        }

        public string Email
        {
            get
            {
                string email = String.Empty;

                if (User != null && User.Claims != null && User.Claims.Count() > 0)
                {
                    var emailClaim = User.Claims
                        .FirstOrDefault(c => c.Type == ClaimTypes.Email);

                    email = emailClaim?.Value ?? string.Empty;
                }

                return email;
            }
        }
    }
}
