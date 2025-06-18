using GameStore.Application.Dtos.Games.CreateGames;
using GameStore.Application.Dtos.Games.GetGame;
using GameStore.Application.Dtos.Games.GetGames;
using GameStore.Application.Dtos.Games.UpdateGames;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Application.Interfaces;
public interface IGameService
{
    Task<GameDto> CreateGameAsync(CreateGameRequestDto request);
    Task<GameDto?> GetGameByKeyAsync(string key);
    Task<GameDto?> GetGameByIdAsync(Guid id);
    Task<IEnumerable<SimpleGameResponseDto>> GetGamesByPlatformAsync(Guid platformId);
    Task<IEnumerable<SimpleGameResponseDto>> GetGamesByGenreAsync(Guid genreId);
    Task<GameResponseDto> UpdateGameAsync(UpdateGameRequestDto request);
    Task DeleteGameAsync(string key);
    Task<IActionResult> SimulateDownloadAsync(string key);
    Task<IEnumerable<SimpleGameResponseDto>> GetAllGamesAsync();
}