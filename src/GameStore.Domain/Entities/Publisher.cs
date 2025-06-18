using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class Publisher
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; } = string.Empty;
        public string? HomePage { get; set; }

        public string? Description { get; set; }

        public ICollection<Game> Games { get; set; } = new List<Game>();
    }

}
