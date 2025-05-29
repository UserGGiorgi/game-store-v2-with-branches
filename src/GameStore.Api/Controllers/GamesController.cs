using FluentValidation;
using GameStore.Application.Dtos.Games.CreateGames;
using GameStore.Application.Dtos.Games.GetGames;
using GameStore.Application.Dtos.Games.UpdateGames;
using GameStore.Application.Dtos.Platforms.CreatePlatform;
using GameStore.Application.Dtos.Platforms.UpdatePlatform;
using GameStore.Application.Interfaces;
using GameStore.Domain.Exceptions;
using GameStore.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Web.Controller;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGameService _gameService;
    private readonly IValidator<CreateGameRequestDto> _createValidator;
    private readonly IValidator<UpdateGameRequestDto> _updateValidator;

    public GamesController(
        IGameService gameService,
        IValidator<CreateGameRequestDto> createValidator,
        IValidator<UpdateGameRequestDto> updateValidator)
    {
        _gameService = gameService;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
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
            return BadRequest(validationResult.ToDictionary());
        }

        try
        {
            var createdGame = await _gameService.CreateGameAsync(request);
            return CreatedAtAction(nameof(GetByKey), new { key = createdGame.Key }, createdGame);
        }
        catch (BadRequestException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{key}")]
    [ResponseCache(Duration = 30)]
    [ProducesResponseType(typeof(GameResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByKey(
        string key,
        CancellationToken cancellationToken)
    {
        var game = await _gameService.GetGameByKeyAsync(key);
        return game != null ? Ok(game) : NotFound();
    }

    [HttpGet("id/{id}")]
    [ProducesResponseType(typeof(GameResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var game = await _gameService.GetGameByIdAsync(id);
        return game != null ? Ok(game) : NotFound();
    }

    [HttpGet("platform/{platformId}")]
    [ProducesResponseType(typeof(IEnumerable<GameResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByPlatform(
        Guid platformId,
        CancellationToken cancellationToken)
    {
        var games = await _gameService.GetGamesByPlatformAsync(platformId);
        return Ok(games);
    }

    [HttpGet("genre/{genreId}")]
    [ProducesResponseType(typeof(IEnumerable<GameResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByGenre(
        Guid genreId,
        CancellationToken cancellationToken)
    {
        var games = await _gameService.GetGamesByGenreAsync(genreId);
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
            return BadRequest(validationResult.ToDictionary());
        }

        try
        {
            var updatedGame = await _gameService.UpdateGameAsync(request);
            return Ok(updatedGame);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (BadRequestException ex)
        {
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
        await _gameService.DeleteGameAsync(key);
        return NoContent();
    }

    [HttpGet("{key}/download")]
    [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Download(
        string key,
        CancellationToken cancellationToken)
    {
        try
        {
            return await _gameService.SimulateDownloadAsync(key);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GameResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var games = await _gameService.GetAllGamesAsync();
        return Ok(games);
    }
}