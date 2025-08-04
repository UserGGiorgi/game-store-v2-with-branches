using GameStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Body { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool HasQuote { get; set; } = false;
        public CommentStatus Status { get; set; } = CommentStatus.Active;

        public Guid? ParentCommentId { get; set; }
        public Comment? ParentComment { get; set; }
        public ICollection<Comment> Replies { get; set; } = new List<Comment>();

        public Guid GameId { get; set; }
        public Game Game { get; set; } = null!;
    }
}
