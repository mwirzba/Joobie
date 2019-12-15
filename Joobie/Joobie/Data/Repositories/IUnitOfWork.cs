using Joobie.Data.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IUnitOfWork
    {
        IJobRepository Jobs { get; }
        ICompanyRepository Companies { get; }
        ICategoryRepository Categories { get; }
        Task<int> CompleteAsync();
    }
}
