namespace GameStore.Application.Dtos.Comments
{
    public record CommentResponseDto(
    Guid Id,
    string Name,
    string Body,
    List<CommentResponseDto> ChildComments
);
}
