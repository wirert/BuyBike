namespace BuyBike.Core.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    using Microsoft.EntityFrameworkCore;

    using Core.Models;
    using Core.Models.Category;
    using Core.Services.Contracts;
    using Infrastructure.Contracts;
    using Infrastructure.Data.Entities;

    public class ProductTypeService : IProductTypeService
    {
        private readonly IRepository repo;

        public ProductTypeService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<ICollection<ProductTypeDto>> GetAllAsync()
        {
            var result = await repo.AllReadonly<ProductType>()
                .Select(t => new ProductTypeDto()
                {
                    Id = t.Id,
                    Name = t.Name,
                    ProductsProperties = t.Properties.Select(p => new AttributeValuesDto()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Values = p.AttributeValues.Select(v => v.Value).Distinct().ToList()
                    }),
                    Categories = t.Categories.Select(c => new CategoryDto()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        SubCategories = c.SubCategories.Select(sc => new CategoryDto()
                        {
                            Id = sc.Id,
                            Name = sc.Name,
                        })
                    })
                }).ToListAsync();

            if (result == null)
            {
                throw new ArgumentNullException("There is no categories in db.");
            }

            return result;
        }        
    }
}
