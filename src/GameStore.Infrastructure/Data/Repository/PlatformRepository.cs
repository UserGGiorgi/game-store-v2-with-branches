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
    public class PlatformRepository : Repository<Platform>, IPlatformRepository
    {
        public PlatformRepository(GameStoreDbContext context) : base(context) { }

        public async Task<Platform?> GetByNameAsync(string name)
            => await _context.Platforms.FirstOrDefaultAsync(p => p.Type == name);

        public async Task<IEnumerable<Platform>> GetPlatformsByGameKeyAsync(string gameKey)
        {
            return await _context.Platforms
                .Include(p => p.Games)
                    .ThenInclude(gp => gp.Game)
                .Where(p => p.Games.Any(gp => gp.Game.Key == gameKey))
                .ToListAsync();
        }

        public async Task<bool> IsAttachedToGamesAsync(Guid platformId)
            => await _context.GamePlatforms.AnyAsync(gp => gp.PlatformId == platformId);
    }
}
