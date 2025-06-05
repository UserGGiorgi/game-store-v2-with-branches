using GameStore.Application.Dtos.Platforms.GetPlatform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Platforms.CreatePlatform
{
    public class CreatePlatformRequestDto
    {
        public PlatformDto Platform { get; set; } = new();
    }
}
