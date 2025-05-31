using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Genres.GetGenre
{
    public class GenreDto
    {
        public string Name { get; set; } = string.Empty;
        public Guid? ParentGenreId { get; set; }
    }
}
