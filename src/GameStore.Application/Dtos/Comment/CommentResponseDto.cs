using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Comment
{
    public class CommentResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public string Body { get; set; } = string.Empty;
        public List<CommentResponseDto> ChildComments { get; set; } = new();
    }
}
