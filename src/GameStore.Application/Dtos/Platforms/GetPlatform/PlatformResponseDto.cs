using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Platforms.GetPlatform
{
    public class PlatformResponseDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
