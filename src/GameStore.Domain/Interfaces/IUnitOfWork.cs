using GameStore.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
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
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);

        Task CommitTransactionAsync(CancellationToken cancellationToken = default);

        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}
