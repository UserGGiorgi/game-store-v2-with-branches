using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Authorization.Role
{
    public class CreateRoleDto
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Permissions { get; set; } = new();
    }
}
