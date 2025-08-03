using GameStore.Application.Dtos.Games.GetGames;
using GameStore.Application.Dtos.Publishers.CreatePublisher;
using GameStore.Application.Dtos.Publishers.GetPublisher;
using GameStore.Application.Dtos.Publishers.UpdatePublisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces.Games
{
    public interface IPublisherService
    {
        Task<PublisherResponseDto> CreatePublisherAsync(CreatePublisherRequestDto createPublisherDto);
        Task<PublisherResponseDto> GetPublisherByIdAsync(Guid id);
        Task<PublisherResponseDto> GetPublisherByCompanyNameAsync(string companyName);
        Task<IEnumerable<PublisherResponseDto>> GetAllPublishersAsync();
        Task<PublisherResponseDto> GetPublisherByGameKeyAsync(string gameKey);
        Task<PublisherResponseDto> UpdatePublisherAsync(UpdatePublisherDto updatePublisherDto);
        Task DeletePublisherAsync(Guid id);
        Task<IEnumerable<GameResponseDto>> GetGamesByPublisherNameAsync(string companyName);
    }
}
