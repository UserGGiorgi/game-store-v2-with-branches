using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Platforms.UpdatePlatform
{
    public class UpdatePlatformRequestDto
    {
        public PlatformUpdateDto Platform { get; set; } = new();
    }
}
