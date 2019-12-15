using System.Collections.Generic;
using System.Threading.Tasks;
using Joobie.Data.Repositories.Interfaces;
using Joobie.Models.JobModels;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Repositories;
using Shop.Data.Repositories.Implementations;

namespace Joobie.Data.Repositories.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext context) : base(context) { }

        public ApplicationContext ApplicationContext
        {
            get { return context as ApplicationContext; }
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await ApplicationContext.Categories
                .ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(long id)
        {
            return await ApplicationContext.Categories
                  .FirstOrDefaultAsync(j => j.Id == id);
        }
    }
}
