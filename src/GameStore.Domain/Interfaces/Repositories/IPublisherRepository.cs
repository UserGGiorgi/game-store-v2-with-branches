using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories
{
    public interface IPublisherRepository : IGenericRepository<Publisher>
    {
        Task<bool> ExistsByCompanyNameAsync(string companyName);

        Task<Publisher?> GetByCompanyNameAsync(string companyName);

        Task<Publisher?> GetByGameKeyAsync(string gameKey);

        Task<IEnumerable<Game>> GetGamesByPublisherNameAsync(string companyName);

        Task<bool> HasGamesAsync(Guid publisherId);
    }
}
