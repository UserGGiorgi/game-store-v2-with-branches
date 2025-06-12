using FluentValidation;
using GameStore.Application.Dtos.Games.CreateGames;
using GameStore.Application.Dtos.Games.GetGame;
using GameStore.Application.Dtos.Games.GetGames;
using GameStore.Application.Dtos.Games.UpdateGames;
using GameStore.Application.Dtos.Platforms.CreatePlatform;
using GameStore.Application.Dtos.Platforms.UpdatePlatform;
using GameStore.Application.Interfaces;
using GameStore.Domain.Exceptions;
using GameStore.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameStore.Web.Controller;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGameService _gameService;
    private readonly IValidator<CreateGameRequestDto> _createValidator;
    private readonly IValidator<UpdateGameRequestDto> _updateValidator;
    private readonly ILogger<GamesController> _logger;

    public GamesController(
        IGameService gameService,
        IValidator<CreateGameRequestDto> createValidator,
        IValidator<UpdateGameRequestDto> updateValidator,
        ILogger<GamesController> logger)
        {
        _gameService = gameService;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SimpleGameResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching all games");

        var games = await _gameService.GetAllGamesAsync();
        _logger.LogInformation($"Retrieved  games");
        return Ok(games);
    }
    [HttpPost]
    [ProducesResponseType(typeof(GameDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateGame(
        [FromBody] CreateGameRequestDto request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new game: {GameName}", request.Game.Name);
        var validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for game creation: {Errors}", validationResult.Errors);
            return BadRequest(validationResult.ToDictionary());
        }

        try
        {
            var createdGame = await _gameService.CreateGameAsync(request);
            _logger.LogInformation("Game created successfully. Key: {GameKey}", createdGame.Key);
            var games = await _gameService.GetAllGamesAsync();
            return CreatedAtAction(nameof(GetAll), games);
        }
        catch (BadRequestException ex)
        {
            _logger.LogError(ex, "Bad request creating game: {Message}", ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{key}")]
    [ResponseCache(Duration = 30)]
    [ProducesResponseType(typeof(GameDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByKey(
        string key,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching game by key: {GameKey}", key);

        var game = await _gameService.GetGameByKeyAsync(key);

        if (game == null)
        {
            _logger.LogWarning("Game not found by key: {GameKey}", key);
            return NotFound();
        }

        _logger.LogDebug("Retrieved game: {@Game}", game);
        return Ok(game);
    }

    [HttpGet("find/{id}")]
    [ProducesResponseType(typeof(GameDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching game by ID: {GameId}", id);

        var game = await _gameService.GetGameByIdAsync(id);

        if (game == null)
        {
            _logger.LogWarning("Game not found by ID: {GameId}", id);
            return NotFound();
        }

        _logger.LogDebug("Retrieved game: {@Game}", game);
        return Ok(game);
    }

    [HttpGet("/api/platforms/{id}/games")]
    [ProducesResponseType(typeof(IEnumerable<SimpleGameResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByPlatform(
        Guid id,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching games by platform ID: {PlatformId}", id);

        var games = await _gameService.GetGamesByPlatformAsync(id);

        return Ok(games);
    }

    [HttpGet("/api/genres/{id}/games")]
    [ProducesResponseType(typeof(IEnumerable<SimpleGameResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByGenre(
        Guid id,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching games by genre ID: {GenreId}", id);
        var games = await _gameService.GetGamesByGenreAsync(id);
        return Ok(games);
    }

    [HttpPut]
    [ProducesResponseType(typeof(GameResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromBody] UpdateGameRequestDto request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating game: {GameKey}", request.Game.Key);
        _logger.LogDebug("Update request: {@Request}", request);

        var validationResult = await _updateValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for game update: {Errors}", validationResult.Errors);
            return BadRequest(validationResult.ToDictionary());
        }

        try
        {
            var updatedGame = await _gameService.UpdateGameAsync(request);
            return Ok(updatedGame);
        }
        catch (NotFoundException ex)
        {
            _logger.LogError(ex, "Game not found during update: {GameKey}", request.Game.Key);
            return NotFound(ex.Message);
        }
        catch (BadRequestException ex)
        {
            _logger.LogError(ex, "Bad request updating game: {Message}", ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{key}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
    string key,
    CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting game: {GameKey}", key);
        try
        {
            await _gameService.DeleteGameAsync(key);
            _logger.LogInformation("Game deleted successfully. Key: {GameKey}", key);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            _logger.LogError(ex, "Game not found during deletion: {GameKey}", key);
            return NotFound(ex.Message);
        }
    }

    [HttpGet("{key}/file")]
    [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Download(
        string key,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Download requested for game: {GameKey}", key);
        try
        {
            var result = await _gameService.SimulateDownloadAsync(key);
            _logger.LogInformation("Download completed for game: {GameKey}", key);
            return result;
        }
        catch (NotFoundException ex)
        {
            _logger.LogError(ex, "Game not found for download: {GameKey}", key);
            return NotFound(ex.Message);
        }
    }
}