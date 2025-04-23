using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Genre
{
    public class UpdateGenreRequestDto
    {
        public GenreUpdateDto Genre { get; set; } = new();
    }
}
