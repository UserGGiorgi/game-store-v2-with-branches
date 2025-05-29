using FluentValidation;
using GameStore.Application.Dtos.Genres.GetGenre;
using GameStore.Application.Dtos.Platforms.CreatePlatform;
using GameStore.Application.Dtos.Platforms.GetPlatform;
using GameStore.Application.Dtos.Platforms.UpdatePlatform;
using GameStore.Application.Interfaces;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Web.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformService _platformService;
        private readonly IValidator<CreatePlatformRequestDto> _createValidator;
        private readonly IValidator<UpdatePlatformRequestDto> _updateValidator;

        public PlatformsController(
            IPlatformService platformService,
            IValidator<CreatePlatformRequestDto> createValidator,
            IValidator<UpdatePlatformRequestDto> updateValidator)
        {
            _platformService = platformService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PlatformResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePlatform([FromBody] CreatePlatformRequestDto request,
        CancellationToken cancellationToken)
        {
            var validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            try
            {
                var createdPlatform = await _platformService.CreatePlatformAsync(request);
                return CreatedAtAction(nameof(GetPlatformById), new { id = createdPlatform.Id }, createdPlatform);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PlatformDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPlatformById(Guid id,
        CancellationToken cancellationToken)
        {
            try
            {
                var platform = await _platformService.GetPlatformByIdAsync(id);
                return Ok(platform);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GenreListDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPlatforms(CancellationToken cancellationToken)
        {
            var platforms = await _platformService.GetAllPlatformsAsync();
            return Ok(platforms);
        }

        [HttpPut]
        [ProducesResponseType(typeof(PlatformDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePlatform([FromBody] UpdatePlatformRequestDto request,
        CancellationToken cancellationToken)
        {
            var validationResult = await _updateValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }
            try
            {
                var updatedPlatform = await _platformService.UpdatePlatformAsync(request);
                return Ok(updatedPlatform);
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePlatform(Guid id,
        CancellationToken cancellationToken)
        {
            try
            {
                await _platformService.DeletePlatformAsync(id);
                return NoContent();
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
