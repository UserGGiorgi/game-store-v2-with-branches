using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Publisher
{
    public class PublisherDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string HomePage { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
