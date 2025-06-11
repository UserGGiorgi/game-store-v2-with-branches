using AutoMapper;
using GameStore.Domain.Entities;
using GameStore.Application.Dtos.Games;
using GameStore.Application.Dtos.Genres;
using GameStore.Application.Dtos.Platforms;
using GameStore.Application.Dtos.Games.GetGames;
using GameStore.Application.Dtos.Genres.GetGenre;
using GameStore.Application.Dtos.Platforms.GetPlatform;
using GameStore.Application.Dtos.Publishers.CreatePublisher;
using GameStore.Application.Dtos.Publishers.GetPublisher;
using GameStore.Application.Dtos.Publishers.UpdatePublisher;

namespace GameStore.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameResponseDto>();

            CreateMap<Genre, GenreDetailsDto>();
            CreateMap<Genre, GenreListDto>();
            CreateMap<Genre, GenreResponseDto>()
                .ForMember(dest => dest.ParentGenreName,
                    opt => opt.MapFrom(src => src.ParentGenre != null ? src.ParentGenre.Name : "None"));

            CreateMap<Platform, PlatformResponseDto>();

            CreateMap<CreatePublisherRequestDto, Publisher>();
            CreateMap<Publisher, PublisherResponseDto>();

            CreateMap<PublisherDto, Publisher>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Games, opt => opt.Ignore());
            CreateMap<UpdatePublisherDto, Publisher>();

        }
    }
}