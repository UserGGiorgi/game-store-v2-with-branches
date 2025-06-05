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
        private IDbContextTransaction _transaction = null!;
        public IGameRepository GameRepository => gameRepository.Value;

        public IGenreRepository GenreRepository => genreRepository.Value;

        public IPlatformRepository PlatformRepository => platformRepository.Value;
        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        => _transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
            => await _transaction.CommitAsync(cancellationToken);

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
            => await _transaction.RollbackAsync(cancellationToken);

        public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();

    }
}