using GameStore.Application.Dtos.Authorization.User.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Authorization.User.Update
{
    public class UpdateUserRequestDto
    {
        public UpdateUserInfoDto User { get; set; } = new UpdateUserInfoDto();
        public List<Guid> Roles { get; set; } = new List<Guid>();
        public string? Password { get; set; }
    }
}
