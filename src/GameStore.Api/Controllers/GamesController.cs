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
[Route("[controller]")]
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
        var validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for game creation: {Errors}", validationResult.Errors);
            return BadRequest(validationResult.ToDictionary());
        }
        var createdGame = await _gameService.CreateGameAsync(request);
        _logger.LogInformation("Game created successfully. Key: {GameKey}", createdGame.Key);
        var games = await _gameService.GetAllGamesAsync();
        return CreatedAtAction(nameof(GetAll), games);

    }

    [HttpGet("{key}")]
    [ResponseCache(Duration = 30)]
    [ProducesResponseType(typeof(GameDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByKey(
        string key,
        CancellationToken cancellationToken)
    {
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
        var game = await _gameService.GetGameByIdAsync(id);

        if (game == null)
        {
            return NotFound();
        }
        _logger.LogDebug("Retrieved game: {@Game}", game);
        return Ok(game);
    }

    [HttpGet("/platforms/{id}/games")]
    [ProducesResponseType(typeof(IEnumerable<SimpleGameResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByPlatform(
        Guid id,
        CancellationToken cancellationToken)
    {
        var games = await _gameService.GetGamesByPlatformAsync(id);
        return Ok(games);
    }

    [HttpGet("/genres/{id}/games")]
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
        var validationResult = await _updateValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for game update: {Errors}", validationResult.Errors);
            return BadRequest(validationResult.ToDictionary());
        }
        var updatedGame = await _gameService.UpdateGameAsync(request);
        return Ok(updatedGame);

    }

    [HttpDelete("{key}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
    string key,
    CancellationToken cancellationToken)
    {
        await _gameService.DeleteGameAsync(key);
        return NoContent();
    }

    [HttpGet("{key}/file")]
    [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Download(
        string key,
        CancellationToken cancellationToken)
    {
        var result = await _gameService.SimulateDownloadAsync(key);
        _logger.LogInformation("Download completed for game: {GameKey}", key);
        return result;
    }
}