using GameStore.Domain.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories.Games
{
    public interface IGameGenreRepository : IGenericRepository<GameGenre>
    {
        Task<IEnumerable<GameGenre>> GetByGameIdAsync(Guid gameId);
    }
}
