namespace BuyBike.Core.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    using Microsoft.EntityFrameworkCore;

    using Core.Models.Category;
    using Core.Services.Contracts;
    using Infrastructure.Contracts;
    using Infrastructure.Data.Entities;

    public class CategoryService : ICategoryService
    {
        private readonly IRepository repo;

        public CategoryService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var result = await repo.AllReadonly<Category>(c => c.ParentCategory == null)
                .Select(c => new CategoryDto()
                {
                    Id = c.Id,
                    Name = c.Name,
                    SubCategories = c.SubCategories.Select(sc => new CategoryDto()
                    {
                        Id = sc.Id,
                        Name = sc.Name,
                    })
                }).ToListAsync();

            if (result == null)
            {
                throw new ArgumentNullException("There is no categories in db.");
            }

            return result;
        }
               
        public async Task<int> GetIdByName(string name)
        {
            var result = await repo.AllReadonly<Category>(c => c.Name.ToLower() == name.ToLower()).Select(c => c.Id).FirstOrDefaultAsync();

            if(result == default)
            {
                throw new ArgumentException("Не съществува такава категория.");
            }

            return result;
        }
    }
}
