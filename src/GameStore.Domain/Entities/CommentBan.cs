using GameStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class CommentBan
    {
        public Guid Id { get; set; }
        public required string Username { get; set; }
        public Guid? GameId { get; set; }
        public Game? Game { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public BanDuration Duration { get; set; }
        public DateTime Expires { get; set; }
    }
}
