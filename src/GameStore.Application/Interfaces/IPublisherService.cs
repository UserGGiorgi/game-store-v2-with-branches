using GameStore.Application.Dtos.Games;
using GameStore.Application.Dtos.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces
{
    public interface IPublisherService
    {
        Task<PublisherDto> CreatePublisherAsync(CreatePublisherDto createPublisherDto);
        Task<PublisherDto> GetPublisherByIdAsync(Guid id);
        Task<PublisherDto> GetPublisherByCompanyNameAsync(string companyName);
        Task<IEnumerable<PublisherDto>> GetAllPublishersAsync();
        Task<PublisherDto> GetPublisherByGameKeyAsync(string gameKey);
        Task<PublisherDto> UpdatePublisherAsync(UpdatePublisherDto updatePublisherDto);
        Task DeletePublisherAsync(Guid id);
        Task<IEnumerable<GameResponseDto>> GetGamesByPublisherNameAsync(string companyName);
    }
}
