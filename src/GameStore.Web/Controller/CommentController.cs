using GameStore.Application.Dtos.Comment;
using GameStore.Application.Interfaces;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Web.Controller
{
    // CommentsController.cs
    [ApiController]
    [Route("games/{key}/comments")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(
            string key,
            [FromBody] CreateCommentRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var comment = await _commentService.AddCommentAsync(
                    key,
                    request.Comment,
                    request.ParentId);

                return CreatedAtAction(
                    nameof(GetComment),
                    new { id = comment.Id },
                    comment);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(Guid id)
        {
            return Ok();
        }

        [HttpGet("{key}/comments")]
        public async Task<IActionResult> GetCommentsByGameKey(string key)
        {
            try
            {
                var comments = await _commentService.GetCommentsByGameKeyAsync(key);
                return Ok(comments);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(string key, Guid id)
        {
            try
            {
                await _commentService.DeleteCommentAsync(key, id);
                return NoContent(); // 204
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
