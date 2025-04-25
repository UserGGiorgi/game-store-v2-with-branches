using GameStore.Application.DTOs.Games;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Games
{
    public class UpdateGameRequestDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public GameUpdateDto Game { get; set; } = new();

        [Required, MinLength(1)]
        public List<Guid> Genres { get; set; } = new List<Guid>();

        [Required, MinLength(1)]
        public List<Guid> Platforms { get; set; } = new List<Guid>();

        [Required]
        public Guid Publisher { get; set; }
    }
}
