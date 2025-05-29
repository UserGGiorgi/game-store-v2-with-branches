using GameStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameStoreDbContext _context;
        private bool _disposed;

        public UnitOfWork(GameStoreDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}
