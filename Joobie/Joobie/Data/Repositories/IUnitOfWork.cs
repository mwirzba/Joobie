using System;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();
    }
}
