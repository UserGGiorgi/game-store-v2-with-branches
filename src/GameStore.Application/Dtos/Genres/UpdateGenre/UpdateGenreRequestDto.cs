using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Genres.UpdateGenre
{
    public class UpdateGenreRequestDto
    {
        public GenreUpdateDto Genre { get; set; } = new();
    }
}
