using GameStore.Application.Dtos.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces
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
