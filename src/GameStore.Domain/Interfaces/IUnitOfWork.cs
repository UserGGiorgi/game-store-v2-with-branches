using GameStore.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGameRepository GameRepository { get; }
        IGenreRepository GenreRepository { get; }
        IPlatformRepository PlatformRepository { get; }
        Task<int> CommitAsync();
    }
}
