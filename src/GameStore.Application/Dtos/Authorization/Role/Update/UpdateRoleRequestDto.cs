using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Authorization.Role.Update
{
    public class UpdateRoleRequestDto
    {
        public RoleUpdateDto Role { get; set; } = new RoleUpdateDto();
        public List<string> Permissions { get; set; } = new List<string>();
    }
}
