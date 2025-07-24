using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities.User
{
    public class RolePermission
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; } = new Role();
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; } = new Permission();
    }
}
