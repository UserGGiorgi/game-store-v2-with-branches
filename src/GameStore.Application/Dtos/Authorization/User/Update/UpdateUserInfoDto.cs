using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Authorization.User.Update
{
    public class UpdateUserInfoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
