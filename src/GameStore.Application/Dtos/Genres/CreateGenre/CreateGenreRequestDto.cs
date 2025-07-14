using GameStore.Application.Dtos.Genres.GetGenre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Genres.CreateGenre
{
    public class CreateGenreRequestDto
    {
        public GenreDto Genre { get; set; } = new();
    }

}
