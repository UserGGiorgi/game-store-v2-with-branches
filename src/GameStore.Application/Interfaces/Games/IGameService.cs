using GameStore.Application.Dtos.Games.CreateGames;
using GameStore.Application.Dtos.Games.Filter;
using GameStore.Application.Dtos.Games.GetGame;
using GameStore.Application.Dtos.Games.GetGames;
using GameStore.Application.Dtos.Games.UpdateGames;
using GameStore.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Application.Interfaces.Games;
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
    Task<(IEnumerable<PaginationGame> Games, int TotalCount)> GetAllGamesAsync(
    int pageNumber,
    int pageSizeOption,
    CancellationToken cancellationToken = default);
    Task<(IEnumerable<PaginationGame> Games, int TotalCount)> GetFilteredGamesAsync(
    GameFilterDto filter,
    SortOption sortBy,
    int pageNumber,
    int pageSize,
    CancellationToken cancellationToken);
    Task<IEnumerable<PaginationGame>> GetAllGamesWithoutPaginationAsync(
    CancellationToken cancellationToken = default);
}