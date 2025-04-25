using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Publisher
{
    public class CreatePublisherDto
    {
        [Required]
        [MaxLength(255)]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Url]
        public string HomePage { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
