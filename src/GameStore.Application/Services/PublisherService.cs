using AutoMapper;
using GameStore.Application.Dtos.Games.GetGames;
using GameStore.Application.Dtos.Publishers.CreatePublisher;
using GameStore.Application.Dtos.Publishers.GetPublisher;
using GameStore.Application.Dtos.Publishers.UpdatePublisher;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces;
using GameStore.Infrastructure.Data;
using GameStore.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services
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
            _logger.LogInformation("Creating publisher: {CompanyName}", createPublisherDto.publisher.CompanyName);

            if (await _unitOfWork.PublisherRepository.ExistsByCompanyNameAsync(createPublisherDto.publisher.CompanyName))
            {
                _logger.LogWarning("Duplicate company name: {CompanyName}", createPublisherDto.publisher.CompanyName);
                throw new BadRequestException("Company name must be unique.");
            }

            var publisher = _mapper.Map<Publisher>(createPublisherDto.publisher);
            await _unitOfWork.PublisherRepository.AddAsync(publisher);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Publisher created successfully: {CompanyName} (ID: {PublisherId})",
                publisher.CompanyName, publisher.Id);

            return _mapper.Map<PublisherResponseDto>(publisher);
        }
        public async Task<PublisherResponseDto> GetPublisherByCompanyNameAsync(string companyName)
        {
            if (string.IsNullOrWhiteSpace(companyName))
            {
                _logger.LogWarning("GetPublisherByCompanyName called with empty company name");
                throw new BadRequestException("Company name cannot be empty.");
            }

            _logger.LogInformation("Retrieving publisher by company name: {CompanyName}", companyName);

            var publisher = await _unitOfWork.PublisherRepository.GetByCompanyNameAsync(companyName);
            if (publisher == null)
            {
                _logger.LogWarning("Publisher not found: {CompanyName}", companyName);
                throw new NotFoundException("Publisher not found.");
            }
            _logger.LogInformation("Successfully retrieved publisher: {CompanyName} (ID: {Id})",publisher.CompanyName, publisher.Id);
            return _mapper.Map<PublisherResponseDto>(publisher);
        }

        public async Task<IEnumerable<PublisherResponseDto>> GetAllPublishersAsync()
        {
            _logger.LogInformation("Retrieving all publishers");

            var publishers = await _unitOfWork.PublisherRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PublisherResponseDto>>(publishers);
        }

        public async Task<PublisherResponseDto> GetPublisherByGameKeyAsync(string gameKey)
        {
            _logger.LogInformation("Retrieving publisher by game key: {GameKey}", gameKey);

            var publisher = await _unitOfWork.PublisherRepository.GetByGameKeyAsync(gameKey);
            if (publisher == null)
            {
                _logger.LogWarning("Publisher not found for game key: {GameKey}", gameKey);
                throw new NotFoundException("Game or associated publisher not found.");
            }

            return _mapper.Map<PublisherResponseDto>(publisher);
        }
        public async Task<PublisherResponseDto> UpdatePublisherAsync(UpdatePublisherDto updatePublisherDto)
        {
            _logger.LogInformation("Updating publisher: {PublisherId}", updatePublisherDto.Id);

            var publisher = await _unitOfWork.PublisherRepository.GetByIdAsync(updatePublisherDto.Id);
            if (publisher == null)
            {
                _logger.LogWarning("Publisher not found for update: {PublisherId}", updatePublisherDto.Id);
                throw new NotFoundException("Publisher not found.");
            }

            if (!string.Equals(publisher.CompanyName, updatePublisherDto.CompanyName, StringComparison.OrdinalIgnoreCase) &&
                await _unitOfWork.PublisherRepository.ExistsByCompanyNameAsync(updatePublisherDto.CompanyName))
            {
                _logger.LogWarning("Duplicate company name during update: {CompanyName}", updatePublisherDto.CompanyName);
                throw new BadRequestException("Company name must be unique.");
            }

            publisher.CompanyName = updatePublisherDto.CompanyName;
            publisher.HomePage = updatePublisherDto.HomePage;
            publisher.Description = updatePublisherDto.Description;

            _unitOfWork.PublisherRepository.Update(publisher);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Publisher updated successfully: {CompanyName} (ID: {PublisherId})",
                publisher.CompanyName, publisher.Id);

            return _mapper.Map<PublisherResponseDto>(publisher);
        }
        public async Task DeletePublisherAsync(Guid id)
        {
            _logger.LogInformation("Deleting publisher: {PublisherId}", id);

            var publisher = await _unitOfWork.PublisherRepository.GetByIdAsync(id);
            if (publisher == null)
            {
                _logger.LogWarning("Publisher not found for deletion: {PublisherId}", id);
                throw new NotFoundException("Publisher not found.");
            }

            if (await _unitOfWork.PublisherRepository.HasGamesAsync(id))
            {
                _logger.LogWarning("Cannot delete publisher {PublisherId} with associated games", id);
                throw new BadRequestException("Cannot delete publisher associated with games.");
            }

            _unitOfWork.PublisherRepository.Delete(publisher);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Publisher deleted successfully: {CompanyName} (ID: {PublisherId})",
                publisher.CompanyName, publisher.Id);
        }

        public async Task<PublisherResponseDto> GetPublisherByIdAsync(Guid id)
        {
            _logger.LogInformation("Retrieving publisher by ID: {PublisherId}", id);

            var publisher = await _unitOfWork.PublisherRepository.GetByIdAsync(id);
            if (publisher == null)
            {
                _logger.LogWarning("Publisher not found: {PublisherId}", id);
                throw new NotFoundException($"Publisher with ID {id} not found.");
            }

            _logger.LogInformation("Successfully retrieved publisher: {CompanyName} (ID: {PublisherId})",
                publisher.CompanyName, publisher.Id);

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

            _logger.LogInformation("Found {GameCount} games for publisher: {CompanyName}",
                games.Count(), companyName);

            return _mapper.Map<IEnumerable<GameResponseDto>>(games);
        }
    }
}
