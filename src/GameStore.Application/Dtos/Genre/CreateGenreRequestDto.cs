using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Genre
{
    public class CreateGenreRequestDto
    {
        [Required]
        public GenreDto Genre { get; set; } = new();
    }

}
