using AutoMapper;
using AutoMapper.QueryableExtensions;
using GameStore.Application.Dtos.Games.CreateGames;
using GameStore.Application.Dtos.Games.GetGames;
using GameStore.Application.Dtos.Games.UpdateGames;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Domain.Interfaces;
using GameStore.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace GameStore.Application.Services;

public class GameService : IGameService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGameRepository _gameRepository;
    private readonly IGenericRepository<Genre> _genreRepository;
    private readonly IGenericRepository<Platform> _platformRepository;
    private readonly IMapper _mapper;

    public GameService(
        IUnitOfWork unitOfWork,
        IGameRepository gameRepository,
        IGenericRepository<Genre> genreRepository,
        IGenericRepository<Platform> platformRepository,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _gameRepository = gameRepository;
        _genreRepository = genreRepository;
        _platformRepository = platformRepository;
        _mapper = mapper;
    }

    public async Task<GameDto> CreateGameAsync(CreateGameRequestDto request)
    {
        if (await _gameRepository.GetByKeyAsync(request.Game.Key) != null)
            throw new BadRequestException("Game key must be unique.");

        var genreIds = request.Genres.ToList();
        var validGenres = await _genreRepository.GetAllAsync();
        validGenres = validGenres.Where(g => genreIds.Contains(g.Id)).ToList();

        if (validGenres.Count() != request.Genres.Count)
            throw new BadRequestException("One or more genres are invalid.");

        var platformIds = request.Platforms.ToList();
        var validPlatforms = await _platformRepository.GetAllAsync();
        validPlatforms = validPlatforms.Where(p => platformIds.Contains(p.Id)).ToList();

        if (validPlatforms.Count() != request.Platforms.Count)
            throw new BadRequestException("One or more platforms are invalid.");

        var game = new Game
        {
            Id = Guid.NewGuid(),
            Name = request.Game.Name,
            Key = request.Game.Key,
            Description = request.Game.Description
        };

        foreach (var genre in validGenres)
        {
            game.Genres.Add(new GameGenre { GenreId = genre.Id });
        }

        foreach (var platform in validPlatforms)
        {
            game.Platforms.Add(new GamePlatform { PlatformId = platform.Id });
        }

        await _gameRepository.AddAsync(game);
        await _unitOfWork.CommitAsync();

        return new GameDto
        {
            Name = game.Name,
            Key = game.Key,
            Description = game.Description
        };
    }

    public async Task<GameResponseDto?> GetGameByKeyAsync(string key)
    {
        var game = await _gameRepository.GetByKeyAsync(key);
        return _mapper.Map<GameResponseDto>(game);
    }

    public async Task<GameResponseDto?> GetGameByIdAsync(Guid id)
    {
        var game = await _gameRepository.GetByIdAsync(id);
        return _mapper.Map<GameResponseDto>(game);
    }

    public async Task<IEnumerable<GameResponseDto>> GetGamesByPlatformAsync(Guid platformId)
    {
        var games = await _gameRepository.GetGamesByPlatformAsync(platformId);
        return _mapper.Map<IEnumerable<GameResponseDto>>(games);
    }

    public async Task<IEnumerable<GameResponseDto>> GetGamesByGenreAsync(Guid genreId)
    {
        var games = await _gameRepository.GetGamesByGenreAsync(genreId);
        return _mapper.Map<IEnumerable<GameResponseDto>>(games);
    }

    public async Task<GameResponseDto> UpdateGameAsync(UpdateGameRequestDto request)
    {
        var game = await _gameRepository.GetByIdAsync(request.Game.Id);
        if (game == null)
            throw new NotFoundException("Game not found");

        if (game.Key != request.Game.Key &&
            await _gameRepository.GetByKeyAsync(request.Game.Key) != null)
        {
            throw new BadRequestException("Game key must be unique");
        }

        game.Name = request.Game.Name;
        game.Key = request.Game.Key;
        game.Description = request.Game.Description;

        var genreIds = request.Genres.ToList();
        var validGenres = await _genreRepository.GetAllAsync();
        validGenres = validGenres.Where(g => genreIds.Contains(g.Id)).ToList();

        if (validGenres.Count() != request.Genres.Count)
            throw new BadRequestException("One or more genres are invalid");

        game.Genres.Clear();
        foreach (var genre in validGenres)
        {
            game.Genres.Add(new GameGenre { GenreId = genre.Id });
        }

        var platformIds = request.Platforms.ToList();
        var validPlatforms = await _platformRepository.GetAllAsync();
        validPlatforms = validPlatforms.Where(p => platformIds.Contains(p.Id)).ToList();

        if (validPlatforms.Count() != request.Platforms.Count)
            throw new BadRequestException("One or more platforms are invalid");

        game.Platforms.Clear();
        foreach (var platform in validPlatforms)
        {
            game.Platforms.Add(new GamePlatform { PlatformId = platform.Id });
        }

        _gameRepository.Update(game);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<GameResponseDto>(game);
    }

    public async Task DeleteGameAsync(string key)
    {
        var game = await _gameRepository.GetByKeyAsync(key);
        if (game == null)
            throw new NotFoundException("Game not found");

        _gameRepository.Delete(game);
        await _unitOfWork.CommitAsync();
    }

    public async Task<IActionResult> SimulateDownloadAsync(string key)
    {
        var game = await _gameRepository.GetByKeyAsync(key);
        if (game == null)
            throw new NotFoundException("Game not found");

        var mockFileContent = $"This would be the game file for {key}";
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(mockFileContent));

        return new FileStreamResult(stream, "application/octet-stream")
        {
            FileDownloadName = $"{key}_mock_download.txt"
        };
    }

    public async Task<IEnumerable<GameResponseDto>> GetAllGamesAsync()
    {
        var games = await _gameRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<GameResponseDto>>(games);
    }
}