using Joobie.Models.JobModels;
using Shop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joobie.Data.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
