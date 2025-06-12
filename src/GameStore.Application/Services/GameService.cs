using AutoMapper;
using AutoMapper.QueryableExtensions;
using GameStore.Application.Dtos.Games.CreateGames;
using GameStore.Application.Dtos.Games.GetGame;
using GameStore.Application.Dtos.Games.GetGames;
using GameStore.Application.Dtos.Games.UpdateGames;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infrastructure.Data;
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
        _logger.LogInformation("Starting game creation process for game key: {GameKey}", request.Game.Key);

        var publisher = await _unitOfWork.PublisherRepository.GetByIdAsync(request.Publisher);
        if (publisher == null)
        {
            _logger.LogWarning("Game creation failed - invalid publisher ID: {PublisherId}", request.Publisher);
            throw new BadRequestException("Specified publisher does not exist.");
        }

        var existingGame = await _unitOfWork.GameRepository.GetByKeyAsync(request.Game.Key);
        if (existingGame != null)
        {
            _logger.LogWarning("Game creation failed - duplicate key: {GameKey}", request.Game.Key);
            throw new BadRequestException("Game key must be unique.");
        }


        var genreIds = request.Genres.ToList();
        var validGenres = await _unitOfWork.GenreRepository.GetAllAsync();
        validGenres = validGenres.Where(g => genreIds.Contains(g.Id)).ToList();

        if (validGenres.Count() != request.Genres.Count)
        {
            var invalidGenres = request.Genres.Except(validGenres.Select(g => g.Id));
            _logger.LogWarning("Invalid genres detected: {InvalidGenres}", invalidGenres);
            throw new BadRequestException("One or more genres are invalid."); 
        }

        var platformIds = request.Platforms.ToList();
        var validPlatforms = await _unitOfWork.PlatformRepository.GetAllAsync();
        validPlatforms = validPlatforms.Where(p => platformIds.Contains(p.Id)).ToList();

        if (validPlatforms.Count() != request.Platforms.Count)
        {
            var invalidPlatforms = request.Platforms.Except(validPlatforms.Select(p => p.Id));
            _logger.LogWarning("Invalid platforms detected: {InvalidPlatforms}", invalidPlatforms);
            throw new BadRequestException("One or more platforms are invalid.");
        }
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

        _logger.LogDebug("Creating game entity with ID: {GameId}", game.Id);
        foreach (var genre in validGenres)
        {
            game.Genres.Add(new GameGenre { GenreId = genre.Id });
            _logger.LogTrace("Added genre {GenreId} to game {GameKey}", genre.Id, game.Key);
        }

        foreach (var platform in validPlatforms)
        {
            game.Platforms.Add(new GamePlatform { PlatformId = platform.Id });
            _logger.LogTrace("Added platform {PlatformId} to game {GameKey}", platform.Id, game.Key);
        }

        try
        {
            await _unitOfWork.GameRepository.AddAsync(game);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Successfully created game {GameKey} with ID {GameId}",
                game.Key, game.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to save game {GameKey} to database", game.Key);
            throw;
        }

        return _mapper.Map<GameDto>(game);
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
        _logger.LogInformation("Updating game {GameId}", request.Game.Id);
        var game = await _unitOfWork.GameRepository.GetByIdAsync(request.Game.Id);

        if (game == null)
        {
            _logger.LogWarning("Game not found: {GameId}", request.Game.Id);
            throw new NotFoundException("Game not found");
        }

        if (game.Key != request.Game.Key)
        {
            var existingGameWithKey = await _unitOfWork.GameRepository.GetByKeyAsync(request.Game.Key);
            if (existingGameWithKey != null)
            {
                _logger.LogWarning("Duplicate key detected. Requested: {RequestKey}, Existing: {ExistingGameId}",
                    request.Game.Key, existingGameWithKey.Id);
                throw new BadRequestException("Game key must be unique");
            }
        }

        game.Name = request.Game.Name;
        game.Key = request.Game.Key;
        game.Description = request.Game.Description;

        var genreIds = request.Genres.ToList();
        var validGenres = await _unitOfWork.GenreRepository.GetAllAsync();
        validGenres = validGenres.Where(g => genreIds.Contains(g.Id)).ToList();

        if (validGenres.Count() != request.Genres.Count)
            throw new BadRequestException("One or more genres are invalid");

        game.Genres.Clear();
        foreach (var genre in validGenres)
        {
            game.Genres.Add(new GameGenre { GenreId = genre.Id });
        }

        var platformIds = request.Platforms.ToList();
        var validPlatforms = await _unitOfWork.PlatformRepository.GetAllAsync();
        validPlatforms = validPlatforms.Where(p => platformIds.Contains(p.Id)).ToList();

        if (validPlatforms.Count() != request.Platforms.Count)
            throw new BadRequestException("One or more platforms are invalid");

        game.Platforms.Clear();
        foreach (var platform in validPlatforms)
        {
            game.Platforms.Add(new GamePlatform { PlatformId = platform.Id });
        }

        _unitOfWork.GameRepository.Update(game);
        try
        {
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation("Game updated: {GameId}", game.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Update failed for game {GameId}", game.Id);
            throw;
        }

        return _mapper.Map<GameResponseDto>(game);
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
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            _logger.LogError(ex, "Failed to delete game: {GameKey}", key);
            throw;
        }
    }

    public async Task<IActionResult> SimulateDownloadAsync(string key)
    {
        _logger.LogInformation("Preparing download for game: {GameKey}", key);
        var game = await _unitOfWork.GameRepository.GetByKeyAsync(key);
        if (game == null)
        {
            _logger.LogWarning("Download failed - Game not found: {GameKey}", key);
            throw new NotFoundException("Game not found");
        }

        _logger.LogDebug("Generating mock download for: {GameKey}", key);
        var mockFileContent = $"This would be the game file for {key}";
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(mockFileContent));

        _logger.LogInformation("Successfully prepared download for: {GameKey}", key);
        return new FileStreamResult(stream, "application/octet-stream")
        {
            FileDownloadName = $"{key}_mock_download.txt"
        };
    }

    public async Task<IEnumerable<SimpleGameResponseDto>> GetAllGamesAsync()
    {
        _logger.LogInformation("Fetching all games");
        try
        {
            var games = await _unitOfWork.GameRepository.GetAllAsync();
            var gameList = games.ToList();

            _logger.LogInformation("Retrieved {GameCount} games", gameList.Count);
            return _mapper.Map<IEnumerable<SimpleGameResponseDto>>(gameList);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve games");
            throw;
        }
    }
}