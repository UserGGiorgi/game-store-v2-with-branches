using GameStore.Domain.Entities.Games;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities.Orders
{
    public class OrderGame
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; } = 1;
        public int? Discount { get; set; }
        public Order Order { get; set; } = null!;
        public Game Game { get; set; } = null!;
    }
}
