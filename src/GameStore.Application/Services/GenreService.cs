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
using Microsoft.Extensions.Logging;

namespace GameStore.Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GenreService> _logger;

        public GenreService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<GenreService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GenreResponseDto> CreateGenreAsync(CreateGenreRequestDto request)
        {
            _logger.LogInformation("Creating genre: {Name}", request.Genre.Name);

            if (await _unitOfWork.GenreRepository.GetByNameAsync(request.Genre.Name) != null)
            {
                _logger.LogWarning("Duplicate genre name: {Name}", request.Genre.Name);
                throw new BadRequestException("Genre name must be unique");
            }

            Guid? parentGenreId = null;
            if (!string.IsNullOrEmpty(request.Genre.ParentGenreId))
            {
                if (!Guid.TryParse(request.Genre.ParentGenreId, out var parsedGuid))
                {
                    _logger.LogWarning("Invalid GUID format for parent genre: {ParentId}", request.Genre.ParentGenreId);
                    throw new BadRequestException("ParentGenreId must be a valid GUID");
                }

                parentGenreId = parsedGuid;

                var parentExists = await _unitOfWork.GenreRepository.ExistsAsync(parentGenreId.Value);
                if (!parentExists)
                {
                    _logger.LogWarning("Invalid parent genre: {ParentId}", parentGenreId);
                    throw new BadRequestException("Parent genre not found");
                }
            }

            var genre = new Genre
            {
                Name = request.Genre.Name,
                ParentGenreId = parentGenreId
            };

            await _unitOfWork.GenreRepository.AddAsync(genre);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation("Created genre ID: {Id}", genre.Id);
            return _mapper.Map<GenreResponseDto>(genre);
        }

        public async Task<GenreDetailsDto> GetGenreByIdAsync(Guid id)
        {
            _logger.LogInformation("Getting genre by ID: {GenreId}", id);
            var genre = await _unitOfWork.GenreRepository.GetByIdAsync(id);
            if (genre == null)
            {
                _logger.LogWarning("Genre not found: {GenreId}", id);
                throw new NotFoundException("Genre not found");
            }

            return _mapper.Map<GenreDetailsDto>(genre);
        }

        public async Task<IEnumerable<GenreListDto>> GetAllGenresAsync()
        {
            _logger.LogInformation("Getting all genres");
            var genres = await _unitOfWork.GenreRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GenreListDto>>(genres.OrderBy(g => g.Name));

            _logger.LogInformation("Returning {GenreCount} genres", result.Count());
            return result;
        }

        public async Task<IEnumerable<GenreListDto>> GetGenresByGameKeyAsync(string key)
        {
            _logger.LogInformation("Getting genres for game: {GameKey}", key);

            if (await _unitOfWork.GameRepository.GetByKeyAsync(key) == null)
            {
                _logger.LogWarning("Game not found: {GameKey}", key);
                throw new NotFoundException("Game not found");
            }

            var genres = await _unitOfWork.GenreRepository.GetGenresByGameKeyAsync(key);
            var result = _mapper.Map<IEnumerable<GenreListDto>>(genres);

            _logger.LogInformation("Found {GenreCount} genres for game {GameKey}", result.Count(), key);
            return result;
        }

        public async Task<IEnumerable<GenreListDto>> GetSubGenresAsync(Guid parentId)
        {
            _logger.LogInformation("Getting subgenres for parent: {ParentId}", parentId);
            var subGenres = await _unitOfWork.GenreRepository.GetSubGenresAsync(parentId);
            var result = _mapper.Map<IEnumerable<GenreListDto>>(subGenres.OrderBy(g => g.Name));

            _logger.LogInformation("Found {SubGenreCount} subgenres for parent {ParentId}", result.Count(), parentId);
            return result;
        }

        public async Task<GenreDetailsDto> UpdateGenreAsync(UpdateGenreRequestDto request)
        {
            _logger.LogInformation("Updating genre ID: {GenreId}", request.Genre.Id);

            var genre = await _unitOfWork.GenreRepository.GetByIdAsync(request.Genre.Id);
            if (genre == null)
            {
                _logger.LogWarning("Genre not found: {GenreId}", request.Genre.Id);
                throw new NotFoundException("Genre not found");
            }

            var existingByName = await _unitOfWork.GenreRepository.GetByNameAsync(request.Genre.Name);
            if (existingByName != null && existingByName.Id != request.Genre.Id)
            {
                _logger.LogWarning("Duplicate genre name: {GenreName}", request.Genre.Name);
                throw new BadRequestException("Genre name must be unique");
            }

            Guid? parentGenreId = null;
            if (!string.IsNullOrEmpty(request.Genre.ParentGenreId))
            {
                if (!Guid.TryParse(request.Genre.ParentGenreId, out var parsedGuid))
                {
                    _logger.LogWarning("Invalid ParentGenreId format: {ParentId}", request.Genre.ParentGenreId);
                    throw new BadRequestException("ParentGenreId must be a valid GUID");
                }
                parentGenreId = parsedGuid;
            }

            if (parentGenreId.HasValue)
            {
                await ValidateParentGenre(parentGenreId.Value, genre.Id);
            }

            genre.Name = request.Genre.Name;
            genre.ParentGenreId = parentGenreId;

            _unitOfWork.GenreRepository.Update(genre);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Successfully updated genre ID: {GenreId}", genre.Id);
            return _mapper.Map<GenreDetailsDto>(genre);
        }

        public async Task DeleteGenreAsync(Guid id)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                _logger.LogInformation("Deleting genre ID: {GenreId}", id);
                var genre = await _unitOfWork.GenreRepository.GetByIdAsync(id);
                if (genre == null)
                {
                    _logger.LogWarning("Genre not found: {GenreId}", id);
                    throw new NotFoundException("Genre not found");
                }

                if (await _unitOfWork.GenreRepository.HasSubGenresAsync(id))
                {
                    _logger.LogWarning("Delete failed - genre has subgenres: {GenreId}", id);
                    throw new BadRequestException("Cannot delete genre with sub-genres");
                }


                if (await _unitOfWork.GenreRepository.IsAttachedToGamesAsync(id))
                {
                    _logger.LogWarning("Delete failed - genre attached to games: {GenreId}", id);
                    throw new BadRequestException("Cannot delete genre associated with games");
                }

                _unitOfWork.GenreRepository.Delete(genre);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Successfully deleted genre ID: {GenreId}", id);
                await _unitOfWork.CommitTransactionAsync();
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
                }
        }
        private async Task ValidateParentGenre(Guid parentGenreId, Guid currentGenreId)
        {
            if (parentGenreId == currentGenreId)
            {
                _logger.LogWarning("Genre cannot be its own parent: {GenreId}", currentGenreId);
                throw new BadRequestException("Genre cannot be its own parent");
            }

            var parentExists = await _unitOfWork.GenreRepository.ExistsAsync(parentGenreId);
            if (!parentExists)
            {
                _logger.LogWarning("Parent genre not found: {ParentId}", parentGenreId);
                throw new BadRequestException("Parent genre not found");
            }
        }
    }
}