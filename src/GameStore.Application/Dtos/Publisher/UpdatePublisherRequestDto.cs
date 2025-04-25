using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Publisher
{
    public class UpdatePublisherRequestDto
    {
        [Required]
        public UpdatePublisherDto Publisher { get; set; } = new UpdatePublisherDto();
    }
}
