using AutoMapper;
using GameStore.Application.Dtos.Games.CreateGames;
using GameStore.Application.Dtos.Games.GetGame;
using GameStore.Application.Dtos.Games.GetGames;
using GameStore.Application.Dtos.Games.UpdateGames;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text;

namespace GameStore.Application.Services;

public class GameService : IGameService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<GameService> _logger;

    public GameService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<GameService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GameDto> CreateGameAsync(CreateGameRequestDto request)
    {
        await ValidatePublisherAsync(request.Publisher);
        await ValidateCreateGameKeysAsync(request.Game.Key);

        var validGenres = await ValidateAndGetGenresAsync(request.Genres);
        var validPlatforms = await ValidateAndGetPlatformsAsync(request.Platforms);

        var game = new Game
        {
            Name = request.Game.Name,
            Key = request.Game.Key,
            Description = request.Game.Description,
            Price = request.Game.Price,
            UnitInStock = request.Game.UnitInStock,
            Discount = request.Game.Discount,
            PublisherId = request.Publisher
        };

        foreach (var genre in validGenres)
        {
            game.Genres.Add(new GameGenre { GenreId = genre.Id });
        }

        foreach (var platform in validPlatforms)
        {
            game.Platforms.Add(new GamePlatform { PlatformId = platform.Id });
        }
        await _unitOfWork.GameRepository.AddAsync(game);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<GameDto>(game);
    }
    private async Task ValidatePublisherAsync(Guid publisherId)
    {
        var publisher = await _unitOfWork.PublisherRepository.GetByIdAsync(publisherId);
        if (publisher == null)
        {
            _logger.LogWarning("Game creation failed - invalid publisher ID: {PublisherId}", publisherId);
            throw new BadRequestException("Specified publisher does not exist.");
        }
    }
    private async Task ValidateCreateGameKeysAsync(string gameKey)
    {
        var existingGame = await _unitOfWork.GameRepository.GetByKeyAsync(gameKey);
        if (existingGame != null)
        {
            _logger.LogWarning("Game creation failed - duplicate key: {GameKey}", gameKey);
            throw new BadRequestException("Game key must be unique.");
        }
    }
    private async Task<List<Genre>> ValidateAndGetGenresAsync(IEnumerable<Guid> genreIds)
    {
        var validGenres = (await _unitOfWork.GenreRepository.GetAllAsync())
            .Where(g => genreIds.Contains(g.Id))
            .ToList();

        if (validGenres.Count != genreIds.Count())
        {
            throw new BadRequestException("One or more genres are invalid.");
        }

        return validGenres;
    }
    private async Task<List<GameStore.Domain.Entities.Platform>> ValidateAndGetPlatformsAsync(IEnumerable<Guid> platformIds)
    {
        var validPlatforms = (await _unitOfWork.PlatformRepository.GetAllAsync())
            .Where(p => platformIds.Contains(p.Id))
            .ToList();

        if (validPlatforms.Count != platformIds.Count())
        {
            throw new BadRequestException("One or more platforms are invalid.");
        }

        return validPlatforms;
    }
    public async Task<GameDto?> GetGameByKeyAsync(string key)
    {
        _logger.LogInformation("Getting game by key: {key}", key);
        var game = await _unitOfWork.GameRepository.GetByKeyAsync(key);
        if (game == null)
        {
            _logger.LogWarning("Game not found - Key: {key}", key);
        }
        return _mapper.Map<GameDto>(game);
    }

    public async Task<GameDto?> GetGameByIdAsync(Guid id)
    {
        _logger.LogInformation("Getting game by ID: {id}", id);
        var game = await _unitOfWork.GameRepository.GetByIdAsync(id);
        if (game == null)
        {
            _logger.LogWarning("Game not found - ID: {id}", id);
        }
        return _mapper.Map<GameDto>(game);
    }

    public async Task<IEnumerable<SimpleGameResponseDto>> GetGamesByPlatformAsync(Guid platformId)
    {
        _logger.LogInformation("Getting games for platform: {platformId}", platformId);
        var games = await _unitOfWork.GameRepository.GetGamesByPlatformAsync(platformId);
        _logger.LogInformation("Found {count} games for platform {platformId}", games.Count(), platformId);
        return _mapper.Map<IEnumerable<SimpleGameResponseDto>>(games);
    }

    public async Task<IEnumerable<SimpleGameResponseDto>> GetGamesByGenreAsync(Guid genreId)
    {
        _logger.LogInformation("Getting games for genre: {genreId}", genreId);
        var games = await _unitOfWork.GameRepository.GetGamesByGenreAsync(genreId);
        _logger.LogInformation("Found {count} games for genre {genreId}", games.Count(), genreId);
        return _mapper.Map<IEnumerable<SimpleGameResponseDto>>(games);
    }

    public async Task<GameResponseDto> UpdateGameAsync(UpdateGameRequestDto request)
    {
        await ValidatePublisherAsync(request.Publisher);
        var game = await ValidateGameAsync(request.Game.Id);

        await ValidateUpdatedGameKeyAsync(request.Game.Key,request.Game.Id);

        game.Name = request.Game.Name;
        game.Key = request.Game.Key;
        game.Description = request.Game.Description;
        game.Discount = request.Game.Discount;

        await UpdateGameGenresAsync(game, request.Genres);
        await UpdateGamePlatformsAsync(game, request.Platforms);

        _unitOfWork.GameRepository.Update(game);

        await _unitOfWork.SaveChangesAsync();
        _logger.LogInformation("Game updated: {GameId}", game.Id);


        return _mapper.Map<GameResponseDto>(game);
    }
    private async Task ValidateUpdatedGameKeyAsync(string gameKey, Guid currentGameId)
    {
        var existingGame = await _unitOfWork.GameRepository.GetByKeyAsync(gameKey);
        if (existingGame != null && existingGame.Id != currentGameId)
        {
            _logger.LogWarning("Duplicate game key detected: {GameKey} for game {GameId}",
                gameKey, currentGameId);
            throw new BadRequestException("Game key must be unique.");
        }
    }
    private async Task<Game> ValidateGameAsync(Guid gameId)
    {
        var game = await _unitOfWork.GameRepository.GetByIdAsync(gameId);

        if (game == null)
        {
            _logger.LogWarning("Game not found: {GameId}", gameId);
            throw new NotFoundException("Game not found");
        }
        return game;
    }
    private async Task UpdateGameGenresAsync(Game game, IEnumerable<Guid> genreIds)
    {
        var currentGameGenres = await _unitOfWork.GameGenreRepository
            .GetByGameIdAsync(game.Id);

        var validGenres = await ValidateAndGetGenresAsync(genreIds);
        var validGenreIds = validGenres.Select(g => g.Id).ToList();

        var genresToRemove = currentGameGenres
            .Where(gg => !validGenreIds.Contains(gg.GenreId))
            .ToList();

        foreach (var gameGenre in genresToRemove)
        {
            _unitOfWork.GameGenreRepository.Delete(gameGenre);
        }

        var existingGenreIds = currentGameGenres.Select(gg => gg.GenreId).ToList();
        foreach (var genreId in validGenreIds)
        {
            if (!existingGenreIds.Contains(genreId))
            {
                await _unitOfWork.GameGenreRepository.AddAsync(new GameGenre
                {
                    GameId = game.Id,
                    GenreId = genreId
                });
            }
        }
    }

    private async Task UpdateGamePlatformsAsync(Game game, IEnumerable<Guid> platformIds)
    {
        var currentGamePlatforms = await _unitOfWork.GamePlatformRepository
            .GetByGameIdAsync(game.Id);

        var validPlatforms = await ValidateAndGetPlatformsAsync(platformIds);
        var validPlatformIds = validPlatforms.Select(p => p.Id).ToList();

        // Remove old
        foreach (var gamePlatform in currentGamePlatforms)
        {
            if (!validPlatformIds.Contains(gamePlatform.PlatformId))
            {
                _unitOfWork.GamePlatformRepository.Delete(gamePlatform);
            }
        }

        // Add new
        var existingPlatformIds = currentGamePlatforms.Select(gp => gp.PlatformId).ToList();
        foreach (var platformId in validPlatformIds)
        {
            if (!existingPlatformIds.Contains(platformId))
            {
               await _unitOfWork.GamePlatformRepository.AddAsync(new GamePlatform
                {
                    GameId = game.Id,
                    PlatformId = platformId
                });
            }
        }
    }
    public async Task DeleteGameAsync(string key)
    {
        await _unitOfWork.BeginTransactionAsync();
        _logger.LogInformation("Attempting to delete game: {GameKey}", key);
        var game = await _unitOfWork.GameRepository.GetByKeyAsync(key);

        if (game == null)
        {
            _logger.LogWarning("Delete failed - Game not found: {GameKey}", key);
            throw new NotFoundException("Game not found");
        }

        try
        {
            _unitOfWork.GameRepository.Delete(game);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation("Successfully deleted game: {GameKey}", key);
            await _unitOfWork.CommitTransactionAsync();
        }
        catch(Exception ex) when(ex is not NotFoundException and not BadRequestException)
        {
            await _unitOfWork.RollbackTransactionAsync();
            _logger.LogError(ex, "Failed to delete game: {GameKey}", key);
            throw;
        }
    }

    public async Task<IActionResult> SimulateDownloadAsync(string key)
    {
        var game = await _unitOfWork.GameRepository.GetByKeyAsync(key);
        if (game == null)
        {
            _logger.LogWarning("Download failed - Game not found: {GameKey}", key);
            throw new NotFoundException("Game not found");
        }

        var mockFileContent = $"This would be the game file for {key}";
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(mockFileContent));

        return new FileStreamResult(stream, "application/octet-stream")
        {
            FileDownloadName = $"{key}_mock_download.txt"
        };
    }

    public async Task<IEnumerable<SimpleGameResponseDto>> GetAllGamesAsync()
    {
        var games = await _unitOfWork.GameRepository.GetAllAsync();
        var gameList = games.ToList();

        _logger.LogInformation("Retrieved {GameCount} games", gameList.Count);
        return _mapper.Map<IEnumerable<SimpleGameResponseDto>>(gameList);
    }
}