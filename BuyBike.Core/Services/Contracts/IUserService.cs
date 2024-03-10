namespace BuyBike.Core.Services.Contracts
{
    using System.Threading.Tasks;
    using BuyBike.Infrastructure.Data.Entities;

    public interface IUserService
    {
        public Task<AppUser?> Authenticate(string username, string password);

        public string GenerateJwt(AppUser user);
    }
}
