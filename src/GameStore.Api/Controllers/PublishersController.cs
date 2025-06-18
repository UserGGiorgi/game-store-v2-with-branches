using FluentValidation;
using GameStore.Application.Dtos.Games.GetGames;
using GameStore.Application.Dtos.Platforms.CreatePlatform;
using GameStore.Application.Dtos.Platforms.GetPlatform;
using GameStore.Application.Dtos.Platforms.UpdatePlatform;
using GameStore.Application.Dtos.Publishers.CreatePublisher;
using GameStore.Application.Dtos.Publishers.GetPublisher;
using GameStore.Application.Dtos.Publishers.UpdatePublisher;
using GameStore.Application.Interfaces;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace GameStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        private readonly IValidator<CreatePublisherRequestDto> _createValidator;
        private readonly IValidator<UpdatePublisherRequestDto> _updateValidator;
        private readonly ILogger<PublishersController> _logger;

        public PublishersController(
            IPublisherService publisherService,
            IValidator<CreatePublisherRequestDto> createValidator,
            IValidator<UpdatePublisherRequestDto> updateValidator,
            ILogger<PublishersController> logger
            )
        {
            _publisherService = publisherService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PublisherResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePublisher([FromBody] CreatePublisherRequestDto request,
            CancellationToken cancellationToken)
        {
            var validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for publisher creation: {Errors}", validationResult.Errors);
                return BadRequest(validationResult.ToDictionary());
            }

            var createdPublisher = await _publisherService.CreatePublisherAsync(request);
            _logger.LogInformation("Publisher created: {CompanyName} (ID: {Id})",
                createdPublisher.CompanyName, createdPublisher.Id);

            return CreatedAtAction(
            nameof(GetPublisherByCompanyName),
            new { companyName = createdPublisher.CompanyName },
            createdPublisher
            );

        }

        [HttpGet("/games/{key}/publisher")]
        [ProducesResponseType(typeof(PublisherResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublisherByGameKey(string key)
        {
            var publisher = await _publisherService.GetPublisherByGameKeyAsync(key);
            _logger.LogInformation("Retrieved publisher for game key: {GameKey} (Publisher ID: {Id})",
                key, publisher.Id);

            return Ok(publisher);

        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PublisherResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPublishers()
        {
            var publishers = await _publisherService.GetAllPublishersAsync();
            return Ok(publishers);
        }

        [HttpPut]
        [ProducesResponseType(typeof(PublisherResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePublisher(
            [FromBody] UpdatePublisherRequestDto request
            , CancellationToken cancellationToken)
        {
            var validationResult = await _updateValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for publisher update: {Errors}", validationResult.Errors);
                return BadRequest(validationResult.ToDictionary());
            }

            var updatedPublisher = await _publisherService.UpdatePublisherAsync(request.Publisher);
            _logger.LogInformation("Publisher updated: {CompanyName} (ID: {Id})",
                updatedPublisher.CompanyName, updatedPublisher.Id);

            return Ok(updatedPublisher);

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePublisher(Guid id)
        {
            await _publisherService.DeletePublisherAsync(id);
            _logger.LogInformation("Publisher deleted: ID {PublisherId}", id);

            return NoContent();

        }

        [HttpGet("{companyName}")]
        [ProducesResponseType(typeof(PublisherResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPublisherByCompanyName(
        string companyName,
        CancellationToken cancellationToken)
        {

            var publisher = await _publisherService.GetPublisherByCompanyNameAsync(companyName);
            _logger.LogInformation("Retrieved publisher: {CompanyName} (ID: {Id})",
                publisher.CompanyName, publisher.Id);
            return Ok(publisher);
        }

        [HttpGet("{companyName}/games")]
        [ProducesResponseType(typeof(IEnumerable<GameResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGamesByPublisherName(string companyName)
        {
            var games = await _publisherService.GetGamesByPublisherNameAsync(companyName);
            _logger.LogInformation("Retrieved {Count} games for publisher: {CompanyName}",
                games.Count(), companyName);

            return Ok(games);

        }
    }

}
