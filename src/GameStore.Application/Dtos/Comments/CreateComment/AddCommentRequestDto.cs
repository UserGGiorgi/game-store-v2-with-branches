using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Comments.CreateComment
{
    public class AddCommentRequestDto
    {
        [JsonPropertyName("comment")]
        public CommentDto Comment { get; set; } = new CommentDto();
        [JsonIgnore]
        public Guid? ParentId { get; set; }

        [JsonPropertyName("parentId")]
        public string? ParentIdRaw
        {
            get => ParentId?.ToString();
            set => ParentId = Guid.TryParse(value, out var guid) ? guid : null;
        }
        [JsonIgnore]
        public CommentAction? Action { get; set; }

        [JsonPropertyName("action")]
        public string? ActionRaw
        {
            get => Action?.ToString();
            set => Action = Enum.TryParse<CommentAction>(value, true, out var action)
                ? action
                : (CommentAction?)null;
        }
    }
    public enum CommentAction
    {
        Reply,
        Quote
    }
}
