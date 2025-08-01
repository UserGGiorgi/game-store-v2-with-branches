using GameStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime? Date { get; set; }
        public DateTime? ShipDate { get; set; }
        public Guid CustomerId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Open;
        public ICollection<OrderGame> OrderGames { get; set; } = new List<OrderGame>();
    }

}
