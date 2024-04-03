namespace BuyBike.Core.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using BuyBike.Core.Models;
    using BuyBike.Core.Services.Contracts;
    using BuyBike.Infrastructure.Contracts;
    using BuyBike.Infrastructure.Data.Entities;
    using BuyBike.Core.Models.Bicycle;
    using BuyBike.Core.Constants;

    /// <summary>
    /// Product Service
    /// </summary>
    public class BicycleService : IBicycleService
    {
        private readonly IRepository repo;

        public BicycleService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<BicycleDetailsDto> GetById(Guid id)
        {            
            var result =  await repo.AllReadonly<Bicycle>(b => b.IsActive && b.Id == id)
                .Select(b => new BicycleDetailsDto
                {
                    Name = b.Name,
                    Make = b.Make.Name,
                    MakeLogoUrl = AppConstants.MinIo_EndPoint + b.Make.LogoUrl,
                    ImageUrl = AppConstants.MinIo_EndPoint + b.ImageUrl,
                    Price = b.Price,
                    DiscountPercent = b.Discount != null ? b.Discount.DiscountPercent : null,
                    Color = b.Color,
                    Category = b.Category.Name,
                    Gender = b.Gender,
                    TyreSize = b.TyreSize,
                    Description = b.Description,
                    Items = b.Items.Select(i => new ItemDto 
                    { 
                        Id = i.Id,
                        Size = i.Size.ToString()!,
                        Sku = i.Sku,
                        IsInStock = i.InStock > 0
                    }),
                    Specification = b.Specification,
                } ).FirstOrDefaultAsync();

            if (result == null)
            {
                throw new ArgumentException("Invalid bicycle identifier.");
            }
          
            return result;
        }
    }
}
