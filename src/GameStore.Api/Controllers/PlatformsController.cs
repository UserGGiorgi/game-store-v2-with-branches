using FluentValidation;
using GameStore.Application.Dtos.Genres.GetGenre;
using GameStore.Application.Dtos.Platforms.CreatePlatform;
using GameStore.Application.Dtos.Platforms.GetPlatform;
using GameStore.Application.Dtos.Platforms.UpdatePlatform;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Web.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformService _platformService;
        private readonly IValidator<CreatePlatformRequestDto> _createValidator;
        private readonly IValidator<UpdatePlatformRequestDto> _updateValidator;
        private readonly ILogger<GamesController> _logger;

        public PlatformsController(
            IPlatformService platformService,
            IValidator<CreatePlatformRequestDto> createValidator,
            IValidator<UpdatePlatformRequestDto> updateValidator,
            ILogger<GamesController> logger)
        {
            _platformService = platformService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PlatformResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePlatform([FromBody] CreatePlatformRequestDto request,
        CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating new platform: {PlatformType}", request.Platform.Type);
            var validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for genre creation: {Errors}", validationResult.Errors);
                return BadRequest(validationResult.ToDictionary());
            }

            try
            {
                var createdPlatform = await _platformService.CreatePlatformAsync(request);
                _logger.LogInformation("platform created successfully. Key: {platform}", createdPlatform.Type);
                var platforms = await _platformService.GetAllPlatformsAsync();
                return CreatedAtAction(nameof(GetAllPlatforms), platforms);
            }
            catch (BadRequestException ex)
            {
                _logger.LogError(ex, "Bad request creating platform: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PlatformDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPlatformById(Guid id,
        CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching platform by ID: {platformId}", id);
            try
            {
                var platform = await _platformService.GetPlatformByIdAsync(id);
                _logger.LogDebug("Retrieved platform: {@platform}", platform);
                return Ok(platform);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/games/{key}/platforms")]
        [ProducesResponseType(typeof(IEnumerable<PlatformResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPlatformsByGameKey(
            string key,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching platforms for game: {GameKey}", key);

            try
            {
                var platforms = await _platformService.GetPlatformsByGameKeyAsync(key);
                _logger.LogInformation("Found {PlatformCount} platforms for game {GameKey}",
                    platforms.Count(), key);
                return Ok(platforms);
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "No platforms found for game: {GameKey}", key);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching platforms for game {GameKey}", key);
                return StatusCode(500, "An error occurred while processing your request");
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GenreListDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPlatforms(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all platforms");
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
            _logger.LogInformation("Updating game: {PlatformType}", request.Platform.Type);
            _logger.LogDebug("Update request: {@Request}", request);
            var validationResult = await _updateValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for platform update: {Errors}", validationResult.Errors);
                return BadRequest(validationResult.ToDictionary());
            }
            try
            {
                var updatedPlatform = await _platformService.UpdatePlatformAsync(request);
                _logger.LogInformation("platform updated successfully. Key: {platform}", updatedPlatform.Type);
                var platforms = await _platformService.GetAllPlatformsAsync();
                return CreatedAtAction(nameof(GetAllPlatforms), platforms);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "platform not found during update: {PlatformType}", request.Platform.Type);
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                _logger.LogError(ex, "Bad request updating platform : {PlatformType}", request.Platform.Type);
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
            _logger.LogInformation("Deleting platform: {PlatformId}", id);
            try
            {
                await _platformService.DeletePlatformAsync(id);
                _logger.LogInformation("paltform deleted successfully. id: {PlatformId}", id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "platform not found during deletion: {PlatformId}", id);
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                _logger.LogError(ex, "bad request during deleting platform: {Platformid}", id);
                return BadRequest(ex.Message);
            }
        }
    }
}
