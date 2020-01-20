using Joobie.Data.Repositories.Interfaces;
using Joobie.Models.JobModels;
using Shop.Data.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joobie.Data.Repositories.Implementations
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return context as ApplicationDbContext; }
        }
    }
}
