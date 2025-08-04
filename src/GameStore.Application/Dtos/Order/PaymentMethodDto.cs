using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Order
{
    public class PaymentMethodDto
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string Title { get; set; }  = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
