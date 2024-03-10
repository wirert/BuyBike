namespace BuyBike.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

    using BuyBike.Core.Services.Contracts;
    using BuyBike.Infrastructure.Constants;
    using BuyBike.Infrastructure.Data.Entities;

    public class UserService : IUserService
    {
        private UserManager<AppUser> userManager;
        private readonly IConfiguration config;        

        public UserService(UserManager<AppUser> _userManager, IConfiguration _config)
        {
            userManager = _userManager;
            config = _config;
        }

        public async Task<AppUser?> Authenticate(string username, string password)
        {
            var user = userManager.FindByNameAsync(username).Result;

            if (user != null && await userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }

            return null;
        }

        public string GenerateJwt(AppUser user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(CustomClaimType.FullName, $"{user.FirstName} {user.LastName}"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]!));

            var token = new JwtSecurityToken(
                issuer: config["JWT:ValidIssuer"],
                audience: config["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha512Signature));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
