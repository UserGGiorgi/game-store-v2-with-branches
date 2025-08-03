using GameStore.Application.Dtos.Genres.CreateGenre;
using GameStore.Application.Dtos.Genres.GetGenre;
using GameStore.Application.Dtos.Genres.UpdateGenre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces.Games
{
    public interface IGenreService
    {
        Task<GenreResponseDto> CreateGenreAsync(CreateGenreRequestDto request);
        Task<GenreDetailsDto> GetGenreByIdAsync(Guid id);
        Task<IEnumerable<GenreListDto>> GetAllGenresAsync();
        Task<IEnumerable<GenreListDto>> GetGenresByGameKeyAsync(string key);
        Task<IEnumerable<GenreListDto>> GetSubGenresAsync(Guid parentId);
        Task<GenreDetailsDto> UpdateGenreAsync(UpdateGenreRequestDto request);
        Task DeleteGenreAsync(Guid id);
    }
}
