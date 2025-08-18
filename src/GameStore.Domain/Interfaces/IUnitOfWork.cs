using GameStore.Domain.Interfaces.Repositories.Auth;
using GameStore.Domain.Interfaces.Repositories.Comments;
using GameStore.Domain.Interfaces.Repositories.Games;
using GameStore.Domain.Interfaces.Repositories.Orders;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IGameRepository GameRepository { get; }
        IGenreRepository GenreRepository { get; }
        IPlatformRepository PlatformRepository { get; }
        IPublisherRepository PublisherRepository { get; }
        IOrderRepository OrderRepository { get; }
        IGameGenreRepository GameGenreRepository { get; }
        IGamePlatformRepository GamePlatformRepository { get; }
        IOrderGameRepository OrderGameRepository { get; }
        ICommentRepository CommentRepository { get; }
        ICommentBanRepository CommentBanRepository { get; }
        IRoleRepository RoleRepository { get; }
        IPermissionRepository PermissionRepository { get; }
        IRolePermissionRepository RolePermissionRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IApplicationUserRepository ApplicationUserRepository { get; }

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);

        Task CommitTransactionAsync(CancellationToken cancellationToken = default);

        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
        Task<IDbContextTransaction> BeginTransactionWithIsolationAsync(
        IsolationLevel isolationLevel = IsolationLevel.ReadCommitted,
        CancellationToken cancellationToken = default);
    }
}
