namespace BuyBike.Infrastructure.Contracts
{
    public interface IUserContext
    {
        string UserId { get; }

        string FullName { get; }

        string Email { get; }
    }
}
