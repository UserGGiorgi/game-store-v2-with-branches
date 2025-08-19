using GameStore.Domain.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories.Games
{
    public interface IPlatformRepository : IGenericRepository<Platform>
    {
        Task<Platform?> GetByNameAsync(string name);
        Task<IEnumerable<Platform>> GetPlatformsByGameKeyAsync(string gameKey);
        Task<bool> IsAttachedToGamesAsync(Guid platformId);
    }
}
