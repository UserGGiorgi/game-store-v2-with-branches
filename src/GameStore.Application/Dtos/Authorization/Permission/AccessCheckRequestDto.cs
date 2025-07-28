using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Authorization.Permission
{
    public class AccessCheckRequestDto
    {
        public string TargetPage { get; set; } = string.Empty;
        public string TargetId { get; set; } = string.Empty;
    }
}
