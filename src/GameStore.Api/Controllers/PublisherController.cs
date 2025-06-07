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
    [Route("api/[controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        private readonly IValidator<CreatePublisherRequestDto> _createValidator;
        private readonly IValidator<UpdatePublisherRequestDto> _updateValidator;
        private readonly ILogger<PublisherController> _logger;

        public PublisherController(
            IPublisherService publisherService,
            IValidator<CreatePublisherRequestDto> createValidator,
            IValidator<UpdatePublisherRequestDto> updateValidator,
            ILogger<PublisherController> logger
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
            _logger.LogInformation("Creating new publisher: {CompanyName}", request.publisher.CompanyName);

            var validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for publisher creation: {Errors}", validationResult.Errors);
                return BadRequest(validationResult.ToDictionary());
            }

            try
            {
                var createdPublisher = await _publisherService.CreatePublisherAsync(request);
                _logger.LogInformation("Publisher created: {CompanyName} (ID: {Id})",
                    createdPublisher.CompanyName, createdPublisher.Id);

                return CreatedAtAction(
            nameof(GetPublisherByCompanyName),
            new { companyName = createdPublisher.CompanyName },
            createdPublisher
        );

            }
            catch (BadRequestException ex)
            {
                _logger.LogError(ex, "Bad request creating publisher: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Name/{companyName}")]
        [ProducesResponseType(typeof(PublisherResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublisherByCompanyName(string companyName)
        {
            _logger.LogInformation("Fetching publisher by name: {CompanyName}", companyName);

            try
            {
                var publisher = await _publisherService.GetPublisherByCompanyNameAsync(companyName);
                _logger.LogInformation("Retrieved publisher: {CompanyName} (ID: {Id})",
                    publisher.CompanyName, publisher.Id);

                return Ok(publisher);
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Publisher not found: {CompanyName}", companyName);
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PublisherResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPublishers()
        {
            _logger.LogInformation("Fetching all publishers");
            var publishers = await _publisherService.GetAllPublishersAsync();
            _logger.LogInformation("Retrieved {Count} publishers", publishers.Count());

            return Ok(publishers);
        }
        [HttpPut]
        [ProducesResponseType(typeof(PublisherResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePublisher(
            [FromBody] UpdatePublisherRequestDto request
            , CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating publisher: {PublisherId}", request.Publisher.Id);
            _logger.LogDebug("Update request: {@Request}", request);

            var validationResult = await _updateValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for publisher update: {Errors}", validationResult.Errors);
                return BadRequest(validationResult.ToDictionary());
            }

            try
            {
                var updatedPublisher = await _publisherService.UpdatePublisherAsync(request.Publisher);
                _logger.LogInformation("Publisher updated: {CompanyName} (ID: {Id})",
                    updatedPublisher.CompanyName, updatedPublisher.Id);

                return Ok(updatedPublisher);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Publisher not found during update: {PublisherId}", request.Publisher.Id);
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                _logger.LogError(ex, "Bad request updating publisher: {PublisherId}", request.Publisher.Id);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePublisher(Guid id)
        {
            _logger.LogInformation("Deleting publisher: {PublisherId}", id);

            try
            {
                await _publisherService.DeletePublisherAsync(id);
                _logger.LogInformation("Publisher deleted: ID {PublisherId}", id);

                return NoContent();
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Publisher not found during deletion: {PublisherId}", id);
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                _logger.LogError(ex, "Bad request deleting publisher: {PublisherId}", id);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{companyName}")]
        [ProducesResponseType(typeof(PublisherResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPublisherByCompanyName(
    string companyName,
    CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching publisher by name: {CompanyName}", companyName);

            try
            {
                var publisher = await _publisherService.GetPublisherByCompanyNameAsync(companyName);
                _logger.LogInformation("Retrieved publisher: {CompanyName} (ID: {Id})",
                    publisher.CompanyName, publisher.Id);

                return Ok(publisher);
            }
            catch (BadRequestException ex)
            {
                _logger.LogWarning(ex, "Invalid request for publisher: {CompanyName}", companyName);
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Publisher not found: {CompanyName}", companyName);
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{companyName}/games")]
        [ProducesResponseType(typeof(IEnumerable<GameResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGamesByPublisherName(string companyName)
        {
            _logger.LogInformation("Fetching games for publisher: {CompanyName}", companyName);

            try
            {
                var games = await _publisherService.GetGamesByPublisherNameAsync(companyName);
                _logger.LogInformation("Retrieved {Count} games for publisher: {CompanyName}",
                    games.Count(), companyName);

                return Ok(games);
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Publisher not found: {CompanyName}", companyName);
                return NotFound(ex.Message);
            }
        }
    }

}
