using GameStore.Domain.Interfaces;
using GameStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Data
{
    public class UnitOfWork(
        GameStoreDbContext context,
        Lazy<IGameRepository> gameRepository,
        Lazy<IGenreRepository> genreRepository,
        Lazy<IPlatformRepository> platformRepository)
        : IUnitOfWork
    {
        private bool _disposed;

        public IGameRepository GameRepository => gameRepository.Value;

        public IGenreRepository GenreRepository => genreRepository.Value;

        public IPlatformRepository PlatformRepository => platformRepository.Value;

        public async Task<int> CommitAsync() => await context.SaveChangesAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                context.Dispose();
            }
            _disposed = true;
        }
    }
}