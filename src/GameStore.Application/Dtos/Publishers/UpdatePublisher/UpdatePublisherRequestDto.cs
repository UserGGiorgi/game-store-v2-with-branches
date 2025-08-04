using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Publishers.UpdatePublisher
{
    public class UpdatePublisherRequestDto
    {
        public UpdatePublisherDto Publisher { get; set; } = new UpdatePublisherDto();
    }
}
