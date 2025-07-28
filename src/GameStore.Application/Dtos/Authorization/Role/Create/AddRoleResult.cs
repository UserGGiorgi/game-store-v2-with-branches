using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Authorization.Role.Create
{
    public class AddRoleResult
    {
        public bool Success { get; set; }
        public Guid? RoleId { get; set; }
        public string? Error { get; set; }
    }
}
