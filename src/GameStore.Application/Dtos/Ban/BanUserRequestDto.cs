using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Ban
{
    public class BanUserRequestDto
    {
        [Required]
        [MaxLength(100)]
        public string User { get; set; } = string.Empty;

        [Required]
        public string Duration { get; set; } = string.Empty;
    }
}
