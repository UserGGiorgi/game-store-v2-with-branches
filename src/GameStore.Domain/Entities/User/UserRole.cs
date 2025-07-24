using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities.User
{
    public class UserRole
    {
        public string UserEmail { get; set; } = string.Empty;
        public Guid RoleId { get; set; }
        public Role Role { get; set; } = new Role();
        public ApplicationUser User { get; set; } = new ApplicationUser();
    }
}
