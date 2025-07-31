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
    public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(GameStoreDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsByCompanyNameAsync(string companyName)
            =>  await _context.Publishers
          .AnyAsync(p => p.CompanyName.ToLower() == companyName.ToLower());

        public async Task<Publisher?> GetByCompanyNameAsync(string companyName)
            => await _context.Publishers
                .FirstOrDefaultAsync(p => p.CompanyName.ToLower() == companyName.ToLower());

        public async Task<Publisher?> GetByGameKeyAsync(string gameKey)
            => await _context.Publishers
                .Include(p => p.Games)
                .FirstOrDefaultAsync(p => p.Games.Any(g => g.Key.ToLower() == gameKey.ToLower()));

        public async Task<IEnumerable<Game>> GetGamesByPublisherNameAsync(string companyName)
            => await _context.Games
                .Include(g => g.Publisher)
                .Where(g => g.Publisher.CompanyName.ToLower() == companyName.ToLower())
                .ToListAsync();

        public async Task<bool> HasGamesAsync(Guid publisherId)
            => await _context.Games
                .AnyAsync(g => g.PublisherId == publisherId);

    }
}
