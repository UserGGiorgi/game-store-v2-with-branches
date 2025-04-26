using AutoMapper;
using GameStore.Application.Dtos.Comment;
using GameStore.Application.Dtos.Games;
using GameStore.Application.Dtos.Genre;
using GameStore.Application.Dtos.Order;
using GameStore.Application.Dtos.Platform;
using GameStore.Application.Dtos.Publisher;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameStore.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameResponseDto>();

            CreateMap<Genre, GenreDetailsDto>();
            CreateMap<Genre, GenreListDto>();
            CreateMap<Game, GameResponseDto>()
            .ForMember(dest => dest.Genres,
                       opt => opt.MapFrom(src => src.Genres.Select(g => g.GenreId)))
            .ForMember(dest => dest.Platforms,
                       opt => opt.MapFrom(src => src.Platforms.Select(p => p.PlatformId)));

            CreateMap<Platform, PlatformResponseDto>();

            CreateMap<CreatePublisherDto, Publisher>();
            CreateMap<Publisher, PublisherDto>();

            CreateMap<UpdatePublisherDto, Publisher>();

            CreateMap<Order, OrderResponseDto>();
            CreateMap<OrderGame, OrderDetailDto>();

            CreateMap<Comment, CommentResponseDto>();
            CreateMap<CreateCommentDto, Comment>();

            CreateMap<Comment, CommentResponseDto>()
            .ForMember(dest => dest.ChildComments,
               opt => opt.MapFrom(src => src.ChildComments));
        }
    }
}
