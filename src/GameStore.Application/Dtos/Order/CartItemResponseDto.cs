using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Order
{
    public class CartItemResponseDto
    {
        public Guid ProductId { get; set; }
        public string GameKey { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
