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
        private readonly AuthRepositoryCollection _authRepository;
        private IDbContextTransaction _transaction = null!;

        public UnitOfWork(
            GameStoreDbContext context,
            GameRepositoryCollection gamerepositories,
            CommentRepositoryCollection commentRepositories,
            AuthRepositoryCollection authRepository)
        {
            _context = context;
            _commentRepositories = commentRepositories;
            _gameRepositories = gamerepositories;
            _authRepository = authRepository;
        }
        public IGameRepository GameRepository => _gameRepositories.Games.Value;

        public IGenreRepository GenreRepository => _gameRepositories.Genres.Value;
        public IPublisherRepository PublisherRepository => _commentRepositories.Publishers.Value;

        public IPlatformRepository PlatformRepository => _gameRepositories.Platforms.Value;
        public IGameGenreRepository GameGenreRepository => _gameRepositories.GameGenres.Value;
        public IGamePlatformRepository GamePlatformRepository => _gameRepositories.GamePlatforms.Value;
        public IOrderRepository OrderRepository => _gameRepositories.Orders.Value;
        public ICommentRepository CommentRepository => _commentRepositories.Comment.Value;
        public ICommentBanRepository CommentBanRepository => _commentRepositories.CommentBan.Value;
        public IOrderGameRepository OrderGameRepository => _gameRepositories.OrderGame.Value;
        public IRoleRepository RoleRepository => _authRepository.Roles.Value;
        public IPermissionRepository PermissionRepository => _authRepository.Permissions.Value;
        public IRolePermissionRepository RolePermissionRepository => _authRepository.RolePermissions.Value;
        public IUserRoleRepository UserRoleRepository => _authRepository.UserRoles.Value;
        public IApplicationUserRepository ApplicationUserRepository => _authRepository.Users.Value;
        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        => _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
            => await _transaction.CommitAsync(cancellationToken);

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
            => await _transaction.RollbackAsync(cancellationToken);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    }
}