using AutoMapper;
using AutoMapper.QueryableExtensions;
using GameStore.Application.Dtos.Genres.GetGenre;
using GameStore.Application.Dtos.Platforms.CreatePlatform;
using GameStore.Application.Dtos.Platforms.GetPlatform;
using GameStore.Application.Dtos.Platforms.UpdatePlatform;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PlatformService> _logger;

        public PlatformService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<PlatformService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PlatformResponseDto> CreatePlatformAsync(CreatePlatformRequestDto request)
        {
            _logger.LogInformation("Creating platform: {PlatformType}", request.Platform.Type);
            if (await _unitOfWork.PlatformRepository.GetByNameAsync(request.Platform.Type) != null)
            {
                _logger.LogWarning("Duplicate platform type: {PlatformType}", request.Platform.Type);
                throw new BadRequestException("Platform type must be unique");
            }

            var platform = new Platform
            {
                Type = request.Platform.Type
            };

            await _unitOfWork.PlatformRepository.AddAsync(platform);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation("Platform created successfully: {PlatformType}", platform.Type);
            return _mapper.Map<PlatformResponseDto>(platform);
        }

        public async Task<PlatformResponseDto> GetPlatformByIdAsync(Guid id)
        {
            _logger.LogInformation("Retrieving platform by ID: {PlatformId}", id);
            var platform = await _unitOfWork.PlatformRepository.GetByIdAsync(id);
            if (platform == null)
            {
                _logger.LogWarning("Platform {PlatformId} not found", id);
                throw new NotFoundException("Platform not found");
            }

            return _mapper.Map<PlatformResponseDto>(platform);
        }

        public async Task<IEnumerable<PlatformResponseDto>> GetAllPlatformsAsync()
        {
            _logger.LogInformation("Retrieving all platforms");
            var platforms = await _unitOfWork.PlatformRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PlatformResponseDto>>(platforms.OrderBy(g => g.Type));
        }

        public async Task<IEnumerable<PlatformResponseDto>> GetPlatformsByGameKeyAsync(string key)
        {
            _logger.LogInformation("Retrieving platforms for game key: {GameKey}", key);
            if (await _unitOfWork.PlatformRepository.GetPlatformsByGameKeyAsync(key) == null)
            {
                _logger.LogWarning("No platforms found for game {GameKey}", key);

                throw new NotFoundException("No platforms found for the specified game key");
            }

            var platforms = await _unitOfWork.PlatformRepository.GetPlatformsByGameKeyAsync(key);
            return _mapper.Map<IEnumerable<PlatformResponseDto>>(platforms);
        }
        public async Task<PlatformResponseDto> UpdatePlatformAsync(UpdatePlatformRequestDto request)
        {
            _logger.LogInformation("Updating platform: {PlatformId}", request.Platform.Id);
            var platform = await _unitOfWork.PlatformRepository.GetByIdAsync(request.Platform.Id)
                ?? throw new NotFoundException("Platform not found");

            var existingByType = await _unitOfWork.PlatformRepository.GetByNameAsync(request.Platform.Type);
            if (existingByType != null && existingByType.Id != platform.Id)
            {
                _logger.LogWarning("Duplicate platform type {PlatformType}", request.Platform.Type);
                throw new BadRequestException("Platform type must be unique");
            }

            platform.Type = request.Platform.Type;
            _unitOfWork.PlatformRepository.Update(platform);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<PlatformResponseDto>(platform);
        }
        public async Task DeletePlatformAsync(Guid id)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                _logger.LogInformation("Deleting platform: {PlatformId}", id);
                var platform = await _unitOfWork.PlatformRepository.GetByIdAsync(id);
                if (platform == null)
                {
                    _logger.LogWarning("Platform {PlatformId} not found for deletion", id);
                    throw new NotFoundException("Platform not found");
                }

                if (platform.Games.Count != 0)
                {
                    _logger.LogWarning("Can't delete platform {PlatformId} - has {GameCount} games", id, platform.Games.Count);
                    throw new BadRequestException("Cannot delete platform associated with games");
                }

                _unitOfWork.PlatformRepository.Delete(platform);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
