using GameStore.Application.Dtos.Platforms.CreatePlatform;
using GameStore.Application.Dtos.Platforms.GetPlatform;
using GameStore.Application.Dtos.Platforms.UpdatePlatform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces.Games
{
    public interface IPlatformService
    {
        Task<PlatformResponseDto> CreatePlatformAsync(CreatePlatformRequestDto request);
        Task<PlatformResponseDto> GetPlatformByIdAsync(Guid id);
        Task<IEnumerable<PlatformResponseDto>> GetAllPlatformsAsync();
        Task<IEnumerable<PlatformResponseDto>> GetPlatformsByGameKeyAsync(string key);
        Task<PlatformResponseDto> UpdatePlatformAsync(UpdatePlatformRequestDto request);
        Task DeletePlatformAsync(Guid id);
    }
}
