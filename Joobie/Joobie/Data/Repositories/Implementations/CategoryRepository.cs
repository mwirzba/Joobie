using Joobie.Data.Repositories.Interfaces;
using Joobie.Models.JobModels;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joobie.Data.Repositories.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext context) : base(context) { }

        public ApplicationContext ApplicationContext
        {
            get { return context as ApplicationContext; }
        }
        public async Task<Category> GetCategoryAsync(long id)
        {
            return await ApplicationContext.Categories
                .FirstOrDefaultAsync(j => j.Id == id);
        }

    }
}
