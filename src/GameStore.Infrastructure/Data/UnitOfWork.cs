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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameStoreDbContext _context;
        private readonly RepositoryCollection _repositories;
        private IDbContextTransaction _transaction = null!;

        public UnitOfWork(GameStoreDbContext context, RepositoryCollection repositories)
        {
            _context = context;
            _repositories = repositories;
        }
        public IGameRepository GameRepository => _repositories.Games.Value;

        public IGenreRepository GenreRepository => _repositories.Genres.Value;
        public IPublisherRepository PublisherRepository => _repositories.Publishers.Value;

        public IPlatformRepository PlatformRepository => _repositories.Platforms.Value;
        public IGameGenreRepository GameGenreRepository => _repositories.GameGenres.Value;
        public IGamePlatformRepository GamePlatformRepository => _repositories.GamePlatforms.Value;
        public IOrderRepository OrderRepository => _repositories.Orders.Value;
        public ICommentRepository CommentRepository => _repositories.Comment.Value;
        public ICommentBanRepository CommentBanRepository => _repositories.CommentBan.Value;
        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        => _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
            => await _transaction.CommitAsync(cancellationToken);

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
            => await _transaction.RollbackAsync(cancellationToken);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    }
}