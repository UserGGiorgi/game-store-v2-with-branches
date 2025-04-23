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
using System.Text;

namespace GameStore.Infrastructure.Services;

public class GameService : IGameService
{
    private readonly GameStoreDbContext _context;
    private readonly IMapper _mapper;

    public GameService(GameStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<GameDto> CreateGameAsync(CreateGameRequestDto request)
    {
        if (await _context.Games.AnyAsync(g => g.Key == request.Game.Key))
            throw new BadRequestException("Game key must be unique.");

        var genres = await _context.Genres
            .Where(g => request.Genres.Contains(g.Id))
            .ToListAsync();

        if (genres.Count != request.Genres.Count)
            throw new BadRequestException("One or more genres are invalid.");

        var platforms = await _context.Platforms
            .Where(p => request.Platforms.Contains(p.Id))
            .ToListAsync();

        if (platforms.Count != request.Platforms.Count)
            throw new BadRequestException("One or more platforms are invalid.");

        var game = new Game
        {
            Id = Guid.NewGuid(),
            Name = request.Game.Name,
            Key = request.Game.Key,
            Description = request.Game.Description
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

        return new GameDto
        {
            Name = game.Name,
            Key = game.Key,
            Description = game.Description
        };
    }
    public async Task<GameResponseDto> GetGameByKeyAsync(string key)
    {
        var game = await _context.Games
            .FirstOrDefaultAsync(g => g.Key == key);

        return _mapper.Map<GameResponseDto>(game);
    }

    public async Task<GameResponseDto> GetGameByIdAsync(Guid id)
    {
        var game = await _context.Games.FindAsync(id);
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
            .FirstOrDefaultAsync(g => g.Id == request.Game.Id);

        if (game == null)
            throw new NotFoundException("Game not found");

        if (game.Key != request.Game.Key &&
            await _context.Games.AnyAsync(g => g.Key == request.Game.Key))
        {
            throw new BadRequestException("Game key must be unique");
        }

        game.Name = request.Game.Name;
        game.Key = request.Game.Key;
        game.Description = request.Game.Description;

        game.Genres.Clear();
        foreach (var genreId in request.Genres)
        {
            if (!await _context.Genres.AnyAsync(g => g.Id == genreId))
                throw new BadRequestException($"Genre {genreId} not found");

            game.Genres.Add(new GameGenre { GenreId = genreId });
        }

        game.Platforms.Clear();
        foreach (var platformId in request.Platforms)
        {
            if (!await _context.Platforms.AnyAsync(p => p.Id == platformId))
                throw new BadRequestException($"Platform {platformId} not found");

            game.Platforms.Add(new GamePlatform { PlatformId = platformId });
        }

        await _context.SaveChangesAsync();
        return _mapper.Map<GameResponseDto>(game);
    }

    public async Task DeleteGameAsync(string key)
    {
        var game = await _context.Games
            .FirstOrDefaultAsync(g => g.Key == key);

        if (game == null)
            throw new NotFoundException("Game not found");

        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
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