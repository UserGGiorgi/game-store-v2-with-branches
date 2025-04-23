using AutoMapper;
using AutoMapper.QueryableExtensions;
using GameStore.Application.Dtos.Genre;
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
    // GenreService.cs
    public class GenreService : IGenreService
    {
        private readonly GameStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreService(GameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GenreResponseDto> CreateGenreAsync(CreateGenreRequestDto request)
        {
            if (await _context.Genres.AnyAsync(g => g.Name == request.Genre.Name))
            {
                throw new ArgumentException("Genre name must be unique");
            }
            if (request.Genre.ParentGenreId.HasValue)
            {
                var parentExists = await _context.Genres
                    .AnyAsync(g => g.Id == request.Genre.ParentGenreId);

                if (!parentExists)
                {
                    throw new ArgumentException("Parent genre not found");
                }
            }

            var genre = new Genre
            {
                Name = request.Genre.Name,
                ParentGenreId = request.Genre.ParentGenreId
            };

            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();

            return _mapper.Map<GenreResponseDto>(genre);
        }

        public async Task<GenreDetailsDto> GetGenreByIdAsync(Guid id)
        {
            var genre = await _context.Genres
                .FirstOrDefaultAsync(g => g.Id == id);

            return genre == null
                ? throw new KeyNotFoundException("Genre not found")
                : _mapper.Map<GenreDetailsDto>(genre);
        }

        public async Task<IEnumerable<GenreListDto>> GetAllGenresAsync()
        {
            return await _context.Genres
                .OrderBy(g => g.Name)
                .ProjectTo<GenreListDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<GenreListDto>> GetGenresByGameKeyAsync(string key)
        {
            var game = await _context.Games
                .Include(g => g.Genres)
                .ThenInclude(gg => gg.Genre)
                .FirstOrDefaultAsync(g => g.Key == key)
                ?? throw new KeyNotFoundException("Game not found");

            return game.Genres
                .Select(gg => _mapper.Map<GenreListDto>(gg.Genre))
                .ToList();
        }

        public async Task<IEnumerable<GenreListDto>> GetSubGenresAsync(Guid parentId)
        {
            return await _context.Genres
                .Where(g => g.ParentGenreId == parentId)
                .OrderBy(g => g.Name)
                .ProjectTo<GenreListDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
        public async Task<GenreDetailsDto> UpdateGenreAsync(UpdateGenreRequestDto request)
        {
            var genre = await _context.Genres
                .FirstOrDefaultAsync(g => g.Id == request.Genre.Id)
                ?? throw new KeyNotFoundException("Genre not found");

            if (genre.Name != request.Genre.Name &&
                await _context.Genres.AnyAsync(g => g.Name == request.Genre.Name))
            {
                throw new ArgumentException("Genre name must be unique");
            }

            if (request.Genre.ParentGenreId.HasValue)
            {
                if (request.Genre.ParentGenreId == genre.Id)
                    throw new ArgumentException("Genre cannot be its own parent");

                var parentExists = await _context.Genres
                    .AnyAsync(g => g.Id == request.Genre.ParentGenreId);

                if (!parentExists)
                    throw new ArgumentException("Parent genre not found");
            }

            if (request.Genre.ParentGenreId.HasValue)
            {
                Guid? currentParentId = request.Genre.ParentGenreId;

                while (currentParentId != null)
                {
                    if (currentParentId == genre.Id)
                        throw new ArgumentException("Circular genre hierarchy detected");

                    currentParentId = await _context.Genres
                        .Where(g => g.Id == currentParentId)
                        .Select(g => g.ParentGenreId)
                        .FirstOrDefaultAsync();
                }
            }

            genre.Name = request.Genre.Name;
            genre.ParentGenreId = request.Genre.ParentGenreId;

            await _context.SaveChangesAsync();
            return _mapper.Map<GenreDetailsDto>(genre);
        }
        public async Task DeleteGenreAsync(Guid id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null) throw new KeyNotFoundException("Genre not found");

            if (await _context.Genres.AnyAsync(g => g.ParentGenreId == id))
                throw new InvalidOperationException("Cannot delete genre with sub-genres");

            if (await _context.GameGenres.AnyAsync(gg => gg.GenreId == id))
                throw new InvalidOperationException("Cannot delete genre associated with games");

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }
    }
}
