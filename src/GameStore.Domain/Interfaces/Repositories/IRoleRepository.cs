using GameStore.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role> 
    {
        Task<Role?> GetByIdWithPermissionsAsync(Guid id);
        Task<bool> ExistsByNameAsync(string name);
        Task<bool> ExistsByNameAsync(string name, Guid excludeRoleId);
    }
}
