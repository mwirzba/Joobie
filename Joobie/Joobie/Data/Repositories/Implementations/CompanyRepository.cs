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
        public CompanyRepository(ApplicationContext context) : base(context) { }

        public ApplicationContext ApplicationContext
        {
            get { return context as ApplicationContext; }
        }
    }
}
