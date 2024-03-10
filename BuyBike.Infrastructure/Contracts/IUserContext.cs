namespace BuyBike.Infrastructure.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal interface IUserContext
    {
        string UserId { get; }

        string FullName { get; }

        string Email { get; }
    }
}
