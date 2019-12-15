using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Joobie.Data.Repositories.Interfaces;
using Joobie.Models.JobModels;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Repositories;
using Shop.Data.Repositories.Implementations;

namespace Joobie.Data.Repositories.Implementations
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(ApplicationContext context) : base(context) { }

        public ApplicationContext ApplicationContext
        {
            get { return context as ApplicationContext; }
        }
        public async Task<IEnumerable<Job>> GetJobsWithAllPropertiesAsync()
        {
            return await ApplicationContext.Jobs
                 .Include(j => j.Category)
                 .Include(j => j.TypeOfContract)
                 .Include(j => j.Company)
                 .Include(j => j.WorkingHours).ToListAsync();
        }

        public async Task<IEnumerable<Job>> GetJobsWithAllPropertiesByFilterAsync(Expression<Func<Job, bool>> predicate)
        {
            return await ApplicationContext.Jobs
                  .Where(predicate)
                  .Include(j => j.Category)
                  .Include(j => j.TypeOfContract)
                  .Include(j => j.Company)
                  .Include(j => j.WorkingHours)
                  .ToListAsync();
        }

        public async Task<Job> GetJobWithAllPropertiesAsync(long id)
        {
            return await ApplicationContext.Jobs
                  .Include(j => j.Category)
                  .Include(j => j.TypeOfContract)
                  .Include(j => j.WorkingHours)
                  .Include(j => j.Company)
                  .FirstOrDefaultAsync(j => j.Id == id);
        }
        //this is temporary 
        public async Task<dynamic> GetListsOfPropertiesAsync()
        {
            return new
            {
                Categories = await ApplicationContext.Categories.ToListAsync(),
                TypesOfContract = await ApplicationContext.TypeOfContracts.ToListAsync(),
                WorkingHours = await ApplicationContext.WorkingHours.ToListAsync()
            }; 
        }       
    }
}
