using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(1000)]
        public string Body { get; set; } = string.Empty;

        public Guid? ParentCommentId { get; set; }

        [Required]
        public Guid GameId { get; set; }

        // Navigation properties
        public Comment? ParentComment { get; set; }
        public ICollection<Comment> ChildComments { get; set; } = new List<Comment>();
        public Game Game { get; set; } = null!;
    }
}
