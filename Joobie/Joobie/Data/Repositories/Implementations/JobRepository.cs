using System.Collections.Generic;
using System.Threading.Tasks;
using Joobie.Data.Repositories.Interfaces;
using Joobie.Models.JobModels;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Repositories;


namespace Joobie.Data.Repositories.Implementations
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(ApplicationContext context) : base(context)  {}
        public async Task<IEnumerable<Job>> GetJobsWithAllPropertiesAsync()
        {
            return await ApplicationContext.Jobs
                 .Include(j => j.Category)
                 .Include(j => j.Salary)
                 .Include(j => j.TypeOfContract)
                 .Include(j => j.WorkingHours).ToListAsync();
        }

        public ApplicationContext ApplicationContext
        {
            get { return context as ApplicationContext; }
        }
    }
}
