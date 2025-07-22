using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories
{
    public interface IGameGenreRepository : IGenericRepository<GameGenre>
    {
        Task<IEnumerable<GameGenre>> GetByGameIdAsync(Guid gameId);
    }
}
