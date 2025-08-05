using FluentValidation;
using GameStore.Application.Dtos.Comments.CreateComment;
using GameStore.Application.Interfaces.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controllers.Comments
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly ILogger<CommentsController> _logger;
        private readonly IValidator<AddCommentRequestDto> _createValidator;

        public CommentsController(
            ICommentService commentService,
            ILogger<CommentsController> logger,
            IValidator<AddCommentRequestDto> createValidator
            )
        {
            _commentService = commentService;
            _logger = logger;
            _createValidator = createValidator;
        }

        [HttpPost("/games/{key}/comments")]
        [Authorize(Policy = "PostComments")]
        public async Task<IActionResult> AddComment(string key, [FromBody] AddCommentRequestDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }
            var comment = await _commentService.AddCommentAsync(key, dto);
            _logger.LogInformation("Comment added for game {GameKey}", key);
            return CreatedAtAction(nameof(GetComments), new { key }, comment);
        }

        [HttpGet("/games/{key}/comments")]
        [Authorize(Policy = "ViewGames")]
        public async Task<IActionResult> GetComments(string key)
        {
            var comments = await _commentService.GetGameCommentsAsync(key);
            return Ok(comments);
        }

        [HttpDelete("/games/{key}/comments/{id}")]
        [Authorize(Policy = "ManageComments")]
        public async Task<IActionResult> DeleteComment(string key, Guid id)
        {
            await _commentService.DeleteCommentAsync(id);
            return NoContent();
        }
    }
}