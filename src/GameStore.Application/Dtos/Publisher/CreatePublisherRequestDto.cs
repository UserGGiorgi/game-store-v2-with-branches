using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Publisher
{
    public class CreatePublisherRequestDto
    {
        [Required]
        public CreatePublisherDto Publisher { get; set; } = new CreatePublisherDto();
    }
}
