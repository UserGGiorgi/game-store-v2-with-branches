using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Comments.CreateComment
{
    public class AddCommentRequestDto
    {
        public CommentDto Comment { get; set; } = new CommentDto();
        public Guid? ParentId { get; set; }
        public CommentAction? Action { get; set; }
    }
    public enum CommentAction
    {
        Reply,
        Quote
    }
}
