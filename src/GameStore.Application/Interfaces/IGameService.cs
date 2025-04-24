using GameStore.Application.Dtos.Games;
using GameStore.Application.DTOs.Games;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Application.Interfaces;
public interface IGameService
{
    Task<GameDto> CreateGameAsync(CreateGameRequestDto request);
    Task<GameResponseDto> GetGameByKeyAsync(string key);
    Task<GameResponseDto> GetGameByIdAsync(Guid id);
    Task<IEnumerable<GameResponseDto>> GetGamesByPlatformAsync(Guid platformId);
    Task<IEnumerable<GameResponseDto>> GetGamesByGenreAsync(Guid genreId);
    Task<GameResponseDto> UpdateGameAsync(UpdateGameRequestDto request);
    Task DeleteGameAsync(string key);
    Task<IActionResult> SimulateDownloadAsync(string key);
    Task<IEnumerable<GameResponseDto>> GetAllGamesAsync();
}