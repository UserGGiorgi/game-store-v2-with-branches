using FluentValidation;
using GameStore.Application.Dtos.Games.CreateGames;
using GameStore.Application.Dtos.Games.Filter;
using GameStore.Application.Dtos.Games.GetGame;
using GameStore.Application.Dtos.Games.GetGames;
using GameStore.Application.Dtos.Games.UpdateGames;
using GameStore.Application.Interfaces.Games;
using GameStore.Domain.Enums;
using GameStore.Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controllers.Games;

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

    [HttpGet("all")]
    [Authorize(Policy = "ViewGames")]
    [ProducesResponseType(typeof(IEnumerable<PaginationGame>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllWithoutPagination(CancellationToken cancellationToken)
    {
        var games = await _gameService.GetAllGamesWithoutPaginationAsync(cancellationToken);
        return Ok(games);
    }

    [HttpGet]
    [Authorize(Policy = "ViewGames")]
    [ProducesResponseType(typeof(PaginatedGamesResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll(
    [FromQuery] GameFilterDto filter,
    [FromQuery(Name = "sort")] string? sort,
    [FromQuery(Name = "page")] int page = 1,
    [FromQuery(Name = "pageCount")] string pageSize = "10",
    CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(pageSize))
        {
            pageSize = "10";
        }

        if (!IsValidPageSize(pageSize, out string errorMessage))
        {
            return BadRequest(errorMessage);
        }

        if (!string.IsNullOrEmpty(filter.Name) && filter.Name.Length < 3)
        {
            return BadRequest("Name filter requires at least 3 characters");
        }

        SortOption sortBy = SortOption.MostPopular;
        if (!string.IsNullOrEmpty(sort) &&
            Enum.TryParse<SortOption>(sort, true, out var parsedSort))
        {
            sortBy = parsedSort;
        }

        int pageSizeValue = GetPageSizeValue(pageSize);

        var (games, totalCount) = await _gameService.GetFilteredGamesAsync(
            filter,
            sortBy,
            page,
            pageSizeValue,
            cancellationToken
        );

        var response = CreatePaginatedResponse(games, totalCount, page, pageSizeValue);

        return Ok(response);
    }

    [HttpPost]
    [Authorize(Policy = "ManageGames")]
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

        return CreatedAtAction(
        nameof(GetByKey),
        new { key = createdGame.Key },
        createdGame);
    }

    [HttpGet("{key}")]
    [Authorize(Policy = "ViewGames")]
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
    [Authorize(Policy = "ViewGames")]
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
    [Authorize(Policy = "ViewGames")]
    [ProducesResponseType(typeof(IEnumerable<SimpleGameResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByPlatform(
        Guid id,
        CancellationToken cancellationToken)
    {
        var games = await _gameService.GetGamesByPlatformAsync(id);
        return Ok(games);
    }

    [HttpGet("/genres/{id}/games")]
    [Authorize(Policy = "ViewGames")]
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
    [Authorize(Policy = "ManageGames")]
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
    [Authorize(Policy = "ManageGames")]
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
    [Authorize(Policy = "ManageGames")]
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


    [HttpGet("pagination-options")]
    [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
    public IActionResult GetPaginationOptions()
    {
        var options = Enum.GetValues(typeof(PaginationOption))
       .Cast<PaginationOption>()
       .Select(x => x == PaginationOption.All ? "all" : ((int)x).ToString());

        return Ok(options);
    }

    [HttpGet("sorting-options")]
    [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
    public IActionResult GetSortingOptions()
    {
        var options = Enum.GetValues(typeof(SortOption))
        .Cast<SortOption>()
        .Select(x => x.GetDescription());

        return Ok(options);
    }

    [HttpGet("publish-date-options")]
    [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
    public IActionResult GetPublishDateOptions()
    {
        var options = Enum.GetValues(typeof(PublishDateOption))
        .Cast<PublishDateOption>()
        .Select(x => x.GetDescription());

        return Ok(options);
    }
    private static bool IsValidPageSize(string pageSize, out string errorMessage)
    {
        errorMessage = "null";

        if (string.IsNullOrWhiteSpace(pageSize))
        {
            errorMessage = "Page size cannot be empty.";
            return false;
        }

        bool isValidNumeric = int.TryParse(pageSize, out int numericSize) &&
                             Enum.IsDefined(typeof(PaginationOption), numericSize);
        bool isValidText = Enum.GetNames(typeof(PaginationOption))
                              .Any(name => name.Equals(pageSize, StringComparison.OrdinalIgnoreCase));
        bool isAll = pageSize.Equals("all", StringComparison.OrdinalIgnoreCase);

        if (isValidNumeric || isValidText || isAll)
        {
            return true;
        }

        var validOptions = Enum.GetValues(typeof(PaginationOption))
                               .Cast<PaginationOption>()
                               .Select(x => x == PaginationOption.All ? "all" : ((int)x).ToString());

        errorMessage = $"Invalid page size. Valid options are: {string.Join(", ", validOptions)}";
        return false;
    }

    private static int GetPageSizeValue(string pageSize)
    {
        if (pageSize.Equals("all", StringComparison.OrdinalIgnoreCase))
        {
            return int.MaxValue;
        }

        if (Enum.TryParse(pageSize, true, out PaginationOption option))
        {
            return option == PaginationOption.All ? int.MaxValue : (int)option;
        }

        return int.Parse(pageSize);
    }

    private PaginatedGamesResponseDto CreatePaginatedResponse(
        IEnumerable<PaginationGame> games,
        int totalCount,
        int currentPage,
        int pageSizeValue)
    {
        var response = new PaginatedGamesResponseDto
        {
            Games = games,
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSizeValue),
            CurrentPage = currentPage
        };

        _logger.LogInformation("Retrieved {Count} games (page {Page} of {TotalPages})",
            response.Games.Count(), currentPage, response.TotalPages);

        return response;
    }
}