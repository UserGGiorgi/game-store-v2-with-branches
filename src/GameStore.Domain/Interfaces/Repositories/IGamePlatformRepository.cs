using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories
{
    public interface IGamePlatformRepository : IGenericRepository<GamePlatform>
    {
        Task<IEnumerable<GamePlatform>> GetByGameIdAsync(Guid gameId);
    }
}
