using AutoMapper;
using GameStore.Application.Dtos.Games;
using GameStore.Application.Dtos.Games.GetGame;
using GameStore.Application.Dtos.Games.GetGames;
using GameStore.Application.Dtos.Genres;
using GameStore.Application.Dtos.Genres.GetGenre;
using GameStore.Application.Dtos.Order;
using GameStore.Application.Dtos.Platforms.GetPlatform;
using GameStore.Application.Dtos.Publishers.CreatePublisher;
using GameStore.Application.Dtos.Publishers.GetPublisher;
using GameStore.Application.Dtos.Publishers.UpdatePublisher;
using GameStore.Domain.Entities.Games;
using GameStore.Domain.Entities.Orders;

namespace GameStore.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GameGenre, Guid>()
            .ConvertUsing(gg => gg.GenreId);

            CreateMap<GamePlatform, Guid>()
                .ConvertUsing(gp => gp.PlatformId);

            CreateMap<Game, GameDto>();
            CreateMap<Game, GameResponseDto>()
            .ForMember(dest => dest.Genres,
                opt => opt.MapFrom(src => src.Genres))
            .ForMember(dest => dest.Platforms,
                opt => opt.MapFrom(src => src.Platforms));
            CreateMap<Game, SimpleGameResponseDto>();

            CreateMap<Game, PaginationGame>()
            .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => (decimal)src.Discount));

            CreateMap<Genre, GenreDetailsDto>();
            CreateMap<Genre, GenreListDto>();
            CreateMap<Genre, GenreResponseDto>()
                .ForMember(dest => dest.ParentGenreName,
                    opt => opt.MapFrom(src => src.ParentGenre != null ? src.ParentGenre.Name : "None"));

            CreateMap<Domain.Entities.Games.Platform, PlatformResponseDto>();

            CreateMap<CreatePublisherRequestDto, Publisher>();
            CreateMap<Publisher, PublisherResponseDto>();

            CreateMap<PublisherDto, Publisher>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Games, opt => opt.Ignore());
            CreateMap<UpdatePublisherDto, Publisher>();

            CreateMap<Order, OrderResponseDto>();
            CreateMap<OrderGame, OrderDetailDto>();

        }
    }
}