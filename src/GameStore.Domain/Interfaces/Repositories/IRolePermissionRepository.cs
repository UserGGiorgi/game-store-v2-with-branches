using GameStore.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories
{
    public interface IRolePermissionRepository : IGenericRepository<RolePermission>
    {
        Task<IEnumerable<RolePermission>> GetForRoleWithPermissionsAsync(Guid roleId);
    }
}
