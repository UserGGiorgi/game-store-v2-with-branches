using GameStore.Domain.Interfaces;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infrastructure.Data.RepositoryCollection;
using Microsoft.EntityFrameworkCore.Storage;

namespace GameStore.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameStoreDbContext _context;
        private readonly GameRepositoryCollection _gameRepositories;
        private readonly CommentRepositoryCollection _commentRepositories;
        private IDbContextTransaction _transaction = null!;

        public UnitOfWork(GameStoreDbContext context,
            GameRepositoryCollection gamerepositories,
            CommentRepositoryCollection commentRepositories)
        {
            _context = context;
            _commentRepositories = commentRepositories;
            _gameRepositories = gamerepositories;
        }
        public IGameRepository GameRepository => _gameRepositories.Games.Value;

        public IGenreRepository GenreRepository => _gameRepositories.Genres.Value;
        public IPublisherRepository PublisherRepository => _gameRepositories.Publishers.Value;

        public IPlatformRepository PlatformRepository => _gameRepositories.Platforms.Value;
        public IGameGenreRepository GameGenreRepository => _gameRepositories.GameGenres.Value;
        public IGamePlatformRepository GamePlatformRepository => _gameRepositories.GamePlatforms.Value;
        public IOrderRepository OrderRepository => _gameRepositories.Orders.Value;
        public ICommentRepository CommentRepository => _commentRepositories.Comment.Value;
        public ICommentBanRepository CommentBanRepository => _commentRepositories.CommentBan.Value;
        public IOrderGameRepository OrderGameRepository => _gameRepositories.OrderGame.Value;
        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        => _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
            => await _transaction.CommitAsync(cancellationToken);

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
            => await _transaction.RollbackAsync(cancellationToken);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    }
}