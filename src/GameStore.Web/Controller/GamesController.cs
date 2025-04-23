using GameStore.Application.Dtos.Games;
using GameStore.Application.DTOs.Games;
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
    private readonly IGenreService _genreService;
    private readonly IPlatformService _platformService;

    public GamesController(IGameService gameService 
        ,IGenreService genreService
        ,IPlatformService platformService)
    {
        _gameService = gameService;
        _genreService = genreService;
        _platformService = platformService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGame([FromBody] CreateGameRequestDto request)
    {
        try
        {
            var createdGame = await _gameService.CreateGameAsync(request);
            return CreatedAtAction(nameof(GetGameByKey), new { key = createdGame.Key }, createdGame);
        }
        catch (BadRequestException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{key}")]
    public async Task<IActionResult> GetGameByKey(string key)
    {
        var game = await _gameService.GetGameByKeyAsync(key);
        return game != null ? Ok(game) : NotFound();
    }

    [HttpGet("find/{id}")]
    public async Task<IActionResult> GetGameById(Guid id)
    {
        var game = await _gameService.GetGameByIdAsync(id);
        return game != null ? Ok(game) : NotFound();
    }

    [HttpGet("~/platforms/{platformId}/games")]
    public async Task<IActionResult> GetGamesByPlatform(Guid platformId)
    {
        var games = await _gameService.GetGamesByPlatformAsync(platformId);
        return Ok(games);
    }

    [HttpGet("~/genres/{genreId}/games")]
    public async Task<IActionResult> GetGamesByGenre(Guid genreId)
    {
        var games = await _gameService.GetGamesByGenreAsync(genreId);
        return Ok(games);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateGame([FromBody] UpdateGameRequestDto request)
    {
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
    public async Task<IActionResult> DeleteGame(string key)
    {
        await _gameService.DeleteGameAsync(key);
        return NoContent();
    }
    [HttpGet("{key}/file")]
    [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SimulateDownload(string key)
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
    public async Task<IActionResult> GetAllGames()
    {
        var games = await _gameService.GetAllGamesAsync();
        return Ok(games);
    }
    [HttpGet("{key}/genres")]
    public async Task<IActionResult> GetGameGenres(string key)
    {
        try
        {
            var genres = await _genreService.GetGenresByGameKeyAsync(key);
            return Ok(genres);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    [HttpGet("{key}/platforms")]
    public async Task<IActionResult> GetGamePlatforms(string key)
    {
        try
        {
            var platforms = await _platformService.GetPlatformsByGameKeyAsync(key);
            return Ok(platforms);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    //private IActionResult GetGame(string key) => Ok();
}