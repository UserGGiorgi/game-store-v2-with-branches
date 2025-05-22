using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Platform
{
    public class PlatformUpdateDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
