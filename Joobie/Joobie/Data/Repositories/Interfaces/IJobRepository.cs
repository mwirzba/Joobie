using Joobie.Models.JobModels;
using Shop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Joobie.Data.Repositories.Interfaces
{
    public interface IJobRepository : IRepository<Job>
    {
        Task<IEnumerable<Job>> GetJobsWithAllPropertiesAsync();
        Task<Job> GetJobWithAllPropertiesAsync(long id);
        Task<IEnumerable<Job>> GetJobsWithAllPropertiesByFilterAsync(Expression<Func<Job, bool>> predicate);
        Task<dynamic> GetListsOfPropertiesAsync();
    }
}
