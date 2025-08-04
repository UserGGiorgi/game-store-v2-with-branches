using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameStore.Application.Dtos.Comments
{
    public record CommentResponseDto(
    Guid Id,
    string Name,
    string Body,
    List<CommentResponseDto> ChildComments
);
}
