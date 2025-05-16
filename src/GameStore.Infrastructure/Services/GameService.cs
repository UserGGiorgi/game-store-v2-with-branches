using AutoMapper;
using AutoMapper.QueryableExtensions;
using GameStore.Application.Dtos.Games;
using GameStore.Application.DTOs.Games;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Text;

namespace GameStore.Infrastructure.Services;

public class GameService : IGameService
{
    private readonly GameStoreDbContext _context;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;

    public GameService(
        GameStoreDbContext context, 
        IMapper mapper, 
        IMemoryCache cache)
    {
        _context = context;
        _mapper = mapper;
        _cache = cache;
    }

    public async Task<GameResponseDto> CreateGameAsync(CreateGameRequestDto request)
    {
        if (await _context.Games.AnyAsync(g => g.Key == request.Game.Key))
            throw new BadRequestException("Game key must be unique");

        if (await _context.Games.AnyAsync(g =>
    EF.Functions.Like(g.Key, request.Game.Key.Trim())))
        {
            throw new BadRequestException("Game key must be unique.");
        }

        var genreIds = await _context.Genres
            .Where(g => request.Genres.Contains(g.Id))
            .Select(g => g.Id)
            .ToListAsync();
        var invalidGenres = request.Genres.Except(genreIds).ToList();
        if (invalidGenres.Count != 0)
            throw new BadRequestException($"Invalid genre IDs: {string.Join(", ", invalidGenres)}");

        var platformIds = await _context.Platforms
            .Where(p => request.Platforms.Contains(p.Id))
            .Select(p => p.Id)
            .ToListAsync();
        var invalidPlatforms = request.Platforms.Except(platformIds).ToList();
        if (invalidPlatforms.Count != 0)
            throw new BadRequestException($"Invalid platform IDs: {string.Join(", ", invalidPlatforms)}");

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

        foreach (var genreId in request.Genres)
        {
            game.Genres.Add(new GameGenre { GenreId = genreId });
        }

        foreach (var platformId in request.Platforms)
        {
            game.Platforms.Add(new GamePlatform { PlatformId = platformId });
        }

        await _context.Games.AddAsync(game);
        await _context.SaveChangesAsync();

        return _mapper.Map<GameResponseDto>(game);
    }
    public async Task<GameResponseDto?> GetGameByKeyAsync(string key)
    {
        var game = await _context.Games
            .FirstOrDefaultAsync(g => g.Key == key);

        return _mapper.Map<GameResponseDto>(game);
    }

    public async Task<GameResponseDto?> GetGameByIdAsync(Guid id)
    {
        var game = await _context.Games
        .Include(g => g.Genres)
        .Include(g => g.Platforms)
        .FirstOrDefaultAsync(g => g.Id == id);
        return _mapper.Map<GameResponseDto>(game);
    }

    public async Task<IEnumerable<GameResponseDto>> GetGamesByPlatformAsync(Guid platformId)
    {
        return await _context.Games
            .Include(g => g.Platforms)
            .Where(g => g.Platforms.Any(p => p.PlatformId == platformId))
            .ProjectTo<GameResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<GameResponseDto>> GetGamesByGenreAsync(Guid genreId)
    {
        return await _context.Games
            .Include(g => g.Genres)
            .Where(g => g.Genres.Any(gg => gg.GenreId == genreId))
            .ProjectTo<GameResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<GameResponseDto> UpdateGameAsync(UpdateGameRequestDto request)
    {
        var game = await _context.Games
            .Include(g => g.Genres)
            .Include(g => g.Platforms)
            .FirstOrDefaultAsync(g => g.Id == request.Id) ?? throw new NotFoundException("Game not found");
        if (await _context.Games.AnyAsync(g => g.Key == request.Game.Key && g.Id != request.Id))
            throw new BadRequestException("Game key must be unique");

        var publisherExists = await _context.Publishers.AnyAsync(p => p.Id == request.Publisher);
        if (!publisherExists) throw new BadRequestException("Invalid publisher ID");

        var validGenreIds = await _context.Genres
            .Where(g => request.Genres.Contains(g.Id))
            .Select(g => g.Id)
            .ToListAsync();
        var invalidGenres = request.Genres.Except(validGenreIds).ToList();
        if (invalidGenres.Count != 0) throw new BadRequestException($"Invalid genre IDs: {string.Join(", ", invalidGenres)}");

        var validPlatformIds = await _context.Platforms
            .Where(p => request.Platforms.Contains(p.Id))
            .Select(p => p.Id)
            .ToListAsync();
        var invalidPlatforms = request.Platforms.Except(validPlatformIds).ToList();
        if (invalidPlatforms.Count != 0) throw new BadRequestException($"Invalid platform IDs: {string.Join(", ", invalidPlatforms)}");

        game.Name = request.Game.Name;
        game.Key = request.Game.Key;
        game.Description = request.Game.Description;
        game.Price = request.Game.Price;
        game.UnitInStock = request.Game.UnitInStock;
        game.Discount = request.Game.Discount;
        game.PublisherId = request.Publisher;

        game.Genres.Clear();
        foreach (var genreId in request.Genres)
        {
            game.Genres.Add(new GameGenre { GenreId = genreId });
        }

        game.Platforms.Clear();
        foreach (var platformId in request.Platforms)
        {
            game.Platforms.Add(new GamePlatform { PlatformId = platformId });
        }

        await _context.SaveChangesAsync();
        return _mapper.Map<GameResponseDto>(game);
    }

    public async Task DeleteGameAsync(string key)
    {
        var game = await _context.Games
            .FirstOrDefaultAsync(g => g.Key == key) ?? throw new NotFoundException("Game not found");
        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
        _cache.Remove("TotalGamesCount");
    }
    public async Task<IActionResult> SimulateDownloadAsync(string key)
    {
        var gameExists = await _context.Games
            .AnyAsync(g => g.Key == key);

        if (!gameExists)
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
        return await _context.Games
            .OrderBy(g => g.Name)
            .ProjectTo<GameResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}