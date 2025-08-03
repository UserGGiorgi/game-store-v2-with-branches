using AutoMapper;
using GameStore.Application.Dtos.Games.GetGames;
using GameStore.Application.Dtos.Publishers.CreatePublisher;
using GameStore.Application.Dtos.Publishers.GetPublisher;
using GameStore.Application.Dtos.Publishers.UpdatePublisher;
using GameStore.Application.Interfaces.Games;
using GameStore.Domain.Entities.Games;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces;
using GameStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Games
{
    public class PublisherService : IPublisherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<IPublisherService> _logger;

        public PublisherService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<IPublisherService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PublisherResponseDto> CreatePublisherAsync(CreatePublisherRequestDto createPublisherDto)
        {
            if (await _unitOfWork.PublisherRepository.ExistsByCompanyNameAsync(createPublisherDto.Publisher.CompanyName))
            {
                _logger.LogWarning("Duplicate company name: {CompanyName}", createPublisherDto.Publisher.CompanyName);
                throw new BadRequestException("Company name must be unique.");
            }

            var publisher = _mapper.Map<Publisher>(createPublisherDto.Publisher);
            await _unitOfWork.PublisherRepository.AddAsync(publisher);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<PublisherResponseDto>(publisher);
        }

        public async Task<PublisherResponseDto> GetPublisherByCompanyNameAsync(string companyName)
        {
            if (string.IsNullOrWhiteSpace(companyName))
            {
                throw new BadRequestException("Company name cannot be empty.");
            }

            var publisher = await _unitOfWork.PublisherRepository.GetByCompanyNameAsync(companyName);
            if (publisher == null)
            {
                throw new NotFoundException("Publisher not found.");
            }
            return _mapper.Map<PublisherResponseDto>(publisher);
        }

        public async Task<IEnumerable<PublisherResponseDto>> GetAllPublishersAsync()
        {
            var publishers = await _unitOfWork.PublisherRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PublisherResponseDto>>(publishers);
        }

        public async Task<PublisherResponseDto> GetPublisherByGameKeyAsync(string gameKey)
        {
            var publisher = await _unitOfWork.PublisherRepository.GetByGameKeyAsync(gameKey);
            if (publisher == null)
            {
                throw new NotFoundException("Game or associated publisher not found.");
            }
            return _mapper.Map<PublisherResponseDto>(publisher);
        }

        public async Task<PublisherResponseDto> UpdatePublisherAsync(UpdatePublisherDto updatePublisherDto)
        {
            var publisher = await _unitOfWork.PublisherRepository.GetByIdAsync(updatePublisherDto.Id);
            if (publisher == null)
            {
                throw new NotFoundException("Publisher not found.");
            }

            if (!string.Equals(publisher.CompanyName, updatePublisherDto.CompanyName, StringComparison.OrdinalIgnoreCase) &&
                await _unitOfWork.PublisherRepository.ExistsByCompanyNameAsync(updatePublisherDto.CompanyName))
            {
                throw new BadRequestException("Company name must be unique.");
            }

            publisher.CompanyName = updatePublisherDto.CompanyName;
            publisher.HomePage = updatePublisherDto.HomePage;
            publisher.Description = updatePublisherDto.Description;

            _unitOfWork.PublisherRepository.Update(publisher);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<PublisherResponseDto>(publisher);
        }
        public async Task DeletePublisherAsync(Guid id)
        {
            var publisher = await _unitOfWork.PublisherRepository.GetByIdAsync(id);
            if (publisher == null)
            {
                throw new NotFoundException("Publisher not found.");
            }

            if (await _unitOfWork.PublisherRepository.HasGamesAsync(id))
            {
                throw new BadRequestException("Cannot delete publisher associated with games.");
            }

            _unitOfWork.PublisherRepository.Delete(publisher);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PublisherResponseDto> GetPublisherByIdAsync(Guid id)
        {
            var publisher = await _unitOfWork.PublisherRepository.GetByIdAsync(id);
            if (publisher == null)
            {
                _logger.LogWarning("Publisher not found: {PublisherId}", id);
                throw new NotFoundException($"Publisher with ID {id} not found.");
            }

            return _mapper.Map<PublisherResponseDto>(publisher);
        }

        public async Task<IEnumerable<GameResponseDto>> GetGamesByPublisherNameAsync(string companyName)
        {
            var publisherExists = await _unitOfWork.PublisherRepository.ExistsByCompanyNameAsync(companyName);
            if (!publisherExists)
            {
                _logger.LogWarning("Publisher not found: {CompanyName}", companyName);
                throw new NotFoundException($"Publisher with company name '{companyName}' not found.");
            }

            var games = await _unitOfWork.PublisherRepository.GetGamesByPublisherNameAsync(companyName);

            return _mapper.Map<IEnumerable<GameResponseDto>>(games);
        }
    }
}
