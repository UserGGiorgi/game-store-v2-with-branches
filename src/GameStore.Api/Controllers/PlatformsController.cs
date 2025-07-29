using FluentValidation;
using GameStore.Application.Dtos.Genres.GetGenre;
using GameStore.Application.Dtos.Platforms.CreatePlatform;
using GameStore.Application.Dtos.Platforms.GetPlatform;
using GameStore.Application.Dtos.Platforms.UpdatePlatform;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Web.Controller
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformService _platformService;
        private readonly IValidator<CreatePlatformRequestDto> _createValidator;
        private readonly IValidator<UpdatePlatformRequestDto> _updateValidator;
        private readonly ILogger<PlatformsController> _logger;

        public PlatformsController(
            IPlatformService platformService,
            IValidator<CreatePlatformRequestDto> createValidator,
            IValidator<UpdatePlatformRequestDto> updateValidator,
            ILogger<PlatformsController> logger)
        {
            _platformService = platformService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _logger = logger;
        }

        [HttpPost]
        //[Authorize(Policy = "ManagePlatforms")]
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
            var createdPlatform = await _platformService.CreatePlatformAsync(request);
            _logger.LogInformation("platform created successfully. Key: {platform}", createdPlatform.Type);
            var platforms = await _platformService.GetAllPlatformsAsync();
            return CreatedAtAction(nameof(GetAllPlatforms), platforms);

        }

        [HttpGet("{id}")]
        //[AllowAnonymous]
        [ProducesResponseType(typeof(PlatformDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPlatformById(Guid id,
        CancellationToken cancellationToken)
        {

            var platform = await _platformService.GetPlatformByIdAsync(id);
            _logger.LogDebug("Retrieved platform: {@platform}", platform);
            return Ok(platform);
        }

        [HttpGet("/games/{key}/platforms")]
        //[AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<PlatformResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPlatformsByGameKey(
            string key,
            CancellationToken cancellationToken)
        {

            var platforms = await _platformService.GetPlatformsByGameKeyAsync(key);
            _logger.LogInformation("Found {PlatformCount} platforms for game {GameKey}",
                platforms.Count(), key);
            return Ok(platforms);
        }

        [HttpGet]
        //[AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<GenreListDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPlatforms(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all platforms");
            var platforms = await _platformService.GetAllPlatformsAsync();
            return Ok(platforms);
        }

        [HttpPut]
        //[Authorize(Policy = "ManagePlatforms")]
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

            var updatedPlatform = await _platformService.UpdatePlatformAsync(request);
            _logger.LogInformation("platform updated successfully. Key: {platform}", updatedPlatform.Type);
            var platforms = await _platformService.GetAllPlatformsAsync();
            return CreatedAtAction(nameof(GetAllPlatforms), platforms);

        }

        [HttpDelete("{id}")]
        //[Authorize(Policy = "ManagePlatforms")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePlatform(Guid id,
        CancellationToken cancellationToken)
        {
            await _platformService.DeletePlatformAsync(id);
            _logger.LogInformation("paltform deleted successfully. id: {PlatformId}", id);
            return NoContent();
        }
    }
}
