using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Authorization.User.Create
{
    public class CreateUserResult
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public string? Email { get; set; }
    }
}
