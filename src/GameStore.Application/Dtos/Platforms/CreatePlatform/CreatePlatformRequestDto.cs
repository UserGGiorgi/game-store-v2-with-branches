using GameStore.Application.Dtos.Platforms.GetPlatform;

namespace GameStore.Application.Dtos.Platforms.CreatePlatform
{
    public class CreatePlatformRequestDto
    {
        public PlatformDto Platform { get; set; } = new();
    }
}
