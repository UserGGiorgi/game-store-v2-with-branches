using GameStore.Domain.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories.Games
{
    public interface IGamePlatformRepository : IGenericRepository<GamePlatform>
    {
        Task<IEnumerable<GamePlatform>> GetByGameIdAsync(Guid gameId);
    }
}
