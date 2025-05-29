using AutoMapper;
using AutoMapper.QueryableExtensions;
using GameStore.Application.Dtos.Genres.CreateGenre;
using GameStore.Application.Dtos.Genres.GetGenre;
using GameStore.Application.Dtos.Genres.UpdateGenre;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Domain.Interfaces;
using GameStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenreRepository _genreRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GenreService(
            IUnitOfWork unitOfWork,
            IGenreRepository genreRepository,
            IGameRepository gameRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _genreRepository = genreRepository;
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<GenreResponseDto> CreateGenreAsync(CreateGenreRequestDto request)
        {
            if (await _genreRepository.GetByNameAsync(request.Genre.Name) != null)
            {
                throw new BadRequestException("Genre name must be unique");
            }

            if (request.Genre.ParentGenreId.HasValue)
            {
                var parentExists = await _genreRepository.ExistsAsync(request.Genre.ParentGenreId.Value);
                if (!parentExists)
                {
                    throw new BadRequestException("Parent genre not found");
                }
            }

            var genre = new Genre
            {
                Name = request.Genre.Name,
                ParentGenreId = request.Genre.ParentGenreId
            };

            await _genreRepository.AddAsync(genre);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<GenreResponseDto>(genre);
        }

        public async Task<GenreDetailsDto> GetGenreByIdAsync(Guid id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            return genre == null
                ? throw new NotFoundException("Genre not found")
                : _mapper.Map<GenreDetailsDto>(genre);
        }

        public async Task<IEnumerable<GenreListDto>> GetAllGenresAsync()
        {
            var genres = await _genreRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GenreListDto>>(genres.OrderBy(g => g.Name));
        }

        public async Task<IEnumerable<GenreListDto>> GetGenresByGameKeyAsync(string key)
        {
            if (await _gameRepository.GetByKeyAsync(key) == null)
                throw new NotFoundException("Game not found");

            var genres = await _genreRepository.GetGenresByGameKeyAsync(key);
            return _mapper.Map<IEnumerable<GenreListDto>>(genres);
        }

        public async Task<IEnumerable<GenreListDto>> GetSubGenresAsync(Guid parentId)
        {
            var subGenres = await _genreRepository.GetSubGenresAsync(parentId);
            return _mapper.Map<IEnumerable<GenreListDto>>(subGenres.OrderBy(g => g.Name));
        }

        public async Task<GenreDetailsDto> UpdateGenreAsync(UpdateGenreRequestDto request)
        {
            var genre = await _genreRepository.GetByIdAsync(request.Genre.Id)
                ?? throw new NotFoundException("Genre not found");

            var existingByName = await _genreRepository.GetByNameAsync(request.Genre.Name);
            if (existingByName != null && existingByName.Id != request.Genre.Id)
            {
                throw new BadRequestException("Genre name must be unique");
            }

            if (request.Genre.ParentGenreId.HasValue)
            {
                if (request.Genre.ParentGenreId == genre.Id)
                    throw new BadRequestException("Genre cannot be its own parent");

                var current = await _genreRepository.GetByIdAsync(request.Genre.ParentGenreId.Value);
                while (current != null)
                {
                    if (current.ParentGenreId == genre.Id)
                        throw new BadRequestException("Circular genre hierarchy detected");

                    current = current.ParentGenreId.HasValue
                        ? await _genreRepository.GetByIdAsync(current.ParentGenreId.Value)
                        : null;
                }

                if (!await _genreRepository.ExistsAsync(request.Genre.ParentGenreId.Value))
                    throw new BadRequestException("Parent genre not found");
            }
            genre.Name = request.Genre.Name;
            genre.ParentGenreId = request.Genre.ParentGenreId;

            _genreRepository.Update(genre);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<GenreDetailsDto>(genre);
        }

        public async Task DeleteGenreAsync(Guid id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null) throw new NotFoundException("Genre not found");

            if (await _genreRepository.HasSubGenresAsync(id))
                throw new BadRequestException("Cannot delete genre with sub-genres");

            if (await _genreRepository.IsAttachedToGamesAsync(id))
                throw new BadRequestException("Cannot delete genre associated with games");

            _genreRepository.Delete(genre);
            await _unitOfWork.CommitAsync();
        }
    }
}