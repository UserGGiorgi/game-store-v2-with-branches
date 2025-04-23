using AutoMapper;
using AutoMapper.QueryableExtensions;
using GameStore.Application.Dtos.Platform;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly GameStoreDbContext _context;
        private readonly IMapper _mapper;

        public PlatformService(GameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PlatformResponseDto> CreatePlatformAsync(CreatePlatformRequestDto request)
        {
            if (await _context.Platforms.AnyAsync(p => p.Type == request.Platform.Type))
            {
                throw new ArgumentException("Platform type must be unique");
            }

            var platform = new Platform
            {
                Type = request.Platform.Type
            };

            await _context.Platforms.AddAsync(platform);
            await _context.SaveChangesAsync();

            return _mapper.Map<PlatformResponseDto>(platform);
        }

        public async Task<PlatformResponseDto> GetPlatformByIdAsync(Guid id)
        {
            var platform = await _context.Platforms.FindAsync(id);
            return platform == null
                ? throw new KeyNotFoundException("Platform not found")
                : _mapper.Map<PlatformResponseDto>(platform);
        }

        public async Task<IEnumerable<PlatformResponseDto>> GetAllPlatformsAsync()
        {
            return await _context.Platforms
                .OrderBy(p => p.Type)
                .ProjectTo<PlatformResponseDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<PlatformResponseDto>> GetPlatformsByGameKeyAsync(string key)
        {
            var game = await _context.Games
                .Include(g => g.Platforms)
                .ThenInclude(gp => gp.Platform)
                .FirstOrDefaultAsync(g => g.Key == key)
                ?? throw new KeyNotFoundException("Game not found");

            return game.Platforms
                .Select(gp => _mapper.Map<PlatformResponseDto>(gp.Platform))
                .ToList();
        }
        public async Task<PlatformResponseDto> UpdatePlatformAsync(UpdatePlatformRequestDto request)
        {
            var platform = await _context.Platforms.FindAsync(request.Platform.Id)
                ?? throw new KeyNotFoundException("Platform not found");

            if (platform.Type != request.Platform.Type &&
                await _context.Platforms.AnyAsync(p => p.Type == request.Platform.Type))
            {
                throw new ArgumentException("Platform type must be unique");
            }

            platform.Type = request.Platform.Type;
            await _context.SaveChangesAsync();

            return _mapper.Map<PlatformResponseDto>(platform);
        }
        public async Task DeletePlatformAsync(Guid id)
        {
            var platform = await _context.Platforms
                .Include(p => p.Games)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (platform == null)
                throw new KeyNotFoundException("Platform not found");

            if (platform.Games.Any())
                throw new InvalidOperationException("Cannot delete platform associated with games");

            _context.Platforms.Remove(platform);
            await _context.SaveChangesAsync();
        }
    }
}
