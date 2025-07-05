using FluentValidation;
using GameStore.Application.Dtos.Comments;
using GameStore.Application.Dtos.Comments.CreateComment;
using GameStore.Application.Dtos.Games.CreateGames;
using GameStore.Application.Interfaces;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using System.Threading;

namespace GameStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<IActionResult> AddComment(string key, [FromBody] AddCommentRequestDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for Comment creation: {Errors}", validationResult.Errors);
                return BadRequest(validationResult.ToDictionary());
            }
            var comment = await _commentService.AddCommentAsync(key, dto);
                return CreatedAtAction(nameof(GetComments), new { key }, comment);
        }

        [HttpGet("/games/{key}/comments")]
        public async Task<IActionResult> GetComments(string key)
        {
                var comments = await _commentService.GetGameCommentsAsync(key);
                return Ok(comments);
        }

        [HttpDelete("/games/{key}/comments/{id}")]
        public async Task<IActionResult> DeleteComment(string key, Guid id)
        {
                await _commentService.DeleteCommentAsync(id);
                return NoContent();
        }

        [HttpGet("ban/durations")]
        public async Task<IActionResult> GetBanDurations()
        {
                var durations = await _commentService.GetBanDurationsAsync();
                return Ok(durations);
        }

        [HttpPost("ban")]
        public async Task<IActionResult> BanUser([FromBody] BanUserDto banDto)
        {
                await _commentService.BanUserAsync(banDto);
                return Ok();
        }
    }
}