using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Platform
{
    public class PlatformDto
    {
        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = string.Empty;
    }
}
