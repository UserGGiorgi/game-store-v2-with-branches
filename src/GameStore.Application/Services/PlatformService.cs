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

        public PlatformService(GameStoreDbContext context,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PlatformResponseDto> CreatePlatformAsync(CreatePlatformRequestDto request)
        {
            if (await _unitOfWork.PlatformRepository.GetByNameAsync(request.Platform.Type) != null)
            {
                throw new BadRequestException("Platform type must be unique");
            }

            var platform = new Platform
            {
                Type = request.Platform.Type
            };

            await _unitOfWork.PlatformRepository.AddAsync(platform);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<PlatformResponseDto>(platform);
        }

        public async Task<PlatformResponseDto> GetPlatformByIdAsync(Guid id)
        {
            var platform = await _unitOfWork.PlatformRepository.GetByIdAsync(id);
            return platform == null
                ? throw new NotFoundException("Platform not found")
                : _mapper.Map<PlatformResponseDto>(platform);
        }

        public async Task<IEnumerable<PlatformResponseDto>> GetAllPlatformsAsync()
        {
            var platforms = await _unitOfWork.PlatformRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PlatformResponseDto>>(platforms.OrderBy(g => g.Type));
        }

        public async Task<IEnumerable<PlatformResponseDto>> GetPlatformsByGameKeyAsync(string key)
        {
            if(await _unitOfWork.PlatformRepository.GetPlatformsByGameKeyAsync(key) == null)
            {
                throw new NotFoundException("No platforms found for the specified game key");
            }

            var platforms = await _unitOfWork.PlatformRepository.GetPlatformsByGameKeyAsync(key);
            return _mapper.Map<IEnumerable<PlatformResponseDto>>(platforms);
        }
        public async Task<PlatformResponseDto> UpdatePlatformAsync(UpdatePlatformRequestDto request)
        {
            var platform = await _unitOfWork.PlatformRepository.GetByIdAsync(request.Platform.Id)
                ?? throw new NotFoundException("Platform not found");

            var existingByType = await _unitOfWork.PlatformRepository.GetByNameAsync(request.Platform.Type);
            if(existingByType != null && existingByType.Id != platform.Id)
            {
                throw new BadRequestException("Platform type must be unique");
            }

            platform.Type = request.Platform.Type;
            _unitOfWork.PlatformRepository.Update(platform);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<PlatformResponseDto>(platform);
        }
        public async Task DeletePlatformAsync(Guid id)
        {
            var platform = await _unitOfWork.PlatformRepository.GetByIdAsync(id);
            if (platform == null)
                throw new NotFoundException("Platform not found");

            if (platform.Games.Count != 0)
                throw new BadRequestException("Cannot delete platform associated with games");

            _unitOfWork.PlatformRepository.Delete(platform);
            await _unitOfWork.CommitAsync();
        }
    }
}
