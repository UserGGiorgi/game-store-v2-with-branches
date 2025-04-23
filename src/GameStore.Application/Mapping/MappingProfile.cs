using AutoMapper;
using GameStore.Application.Dtos.Games;
using GameStore.Application.Dtos.Genre;
using GameStore.Application.Dtos.Platform;
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
            CreateMap<Genre, GenreResponseDto>()
    .ForMember(dest => dest.ParentGenreName,
        opt => opt.MapFrom(src => src.ParentGenre != null
            ? src.ParentGenre.Name
            : "None"));

            CreateMap<Platform, PlatformResponseDto>();
        }
    }
}
