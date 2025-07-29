using GameStore.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories
{
    public interface IPermissionRepository : IGenericRepository<Permission>
    {
        Task<List<Permission>> GetByNamesAsync(IEnumerable<string> names);
    }
}
