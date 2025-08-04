using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Data.Repository
{
    public class GamePlatformRepository : GenericRepository<GamePlatform>, IGamePlatformRepository
    {
        public GamePlatformRepository(GameStoreDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<GamePlatform>> GetByGameIdAsync(Guid gameId)
        {
            return await _context.GamePlatforms
                .Where(gp => gp.GameId == gameId)
                .ToListAsync();
        }
    }
}
