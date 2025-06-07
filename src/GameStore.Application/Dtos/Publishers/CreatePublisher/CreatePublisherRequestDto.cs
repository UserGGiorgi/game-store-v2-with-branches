using GameStore.Application.Dtos.Platforms.GetPlatform;
using GameStore.Application.Dtos.Publishers.GetPublisher;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Publishers.CreatePublisher
{
    public class CreatePublisherRequestDto
    {
        public PublisherDto publisher { get; set; } = new();
    }
}
