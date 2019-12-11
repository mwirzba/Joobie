
using Joobie.Data;
using Joobie.Data.Repositories.Implementations;
using Joobie.Data.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationContext _context;
        public IJobRepository Jobs { get; }

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Jobs = new JobRepository(_context);
        }


        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            //_context.Dispose();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

       
    }
}
