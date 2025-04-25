using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Platform
{
    public class UpdatePlatformRequestDto
    {
        [Required]
        public PlatformUpdateDto Platform { get; set; } = new();
    }
}
