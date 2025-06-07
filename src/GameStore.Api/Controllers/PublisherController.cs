using FluentValidation;
using GameStore.Application.Dtos.Platforms.CreatePlatform;
using GameStore.Application.Dtos.Platforms.UpdatePlatform;
using GameStore.Application.Dtos.Publishers.CreatePublisher;
using GameStore.Application.Dtos.Publishers.UpdatePublisher;
using GameStore.Application.Interfaces;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        private readonly IValidator<CreatePublisherRequestValidator> _createValidator;
        private readonly IValidator<UpdatePublisherDtoValidator> _updateValidator;
        private readonly ILogger<PublisherController> _logger;

        public PublisherController(
            IPublisherService publisherService,
            IValidator<CreatePublisherRequestValidator> createValidator,
            IValidator<UpdatePublisherDtoValidator> updateValidator,
            ILogger<PublisherController> logger
            )
        {
            _publisherService = publisherService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublisher([FromBody] CreatePublisherDto request)
        {
            var publisherDto = await _publisherService.CreatePublisherAsync(request);
            return CreatedAtAction(nameof(GetPublisherById), new { id = publisherDto.Id }, publisherDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisherById(Guid id)
        {
            try
            {
                var publisher = await _publisherService.GetPublisherByIdAsync(id);
                return Ok(publisher);
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Publisher not found");
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Name/{companyName}")]
        public async Task<IActionResult> GetPublisherByCompanyName(string companyName)
        {
            var publisher = await _publisherService.GetPublisherByCompanyNameAsync(companyName);
            return Ok(publisher);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPublishers()
        {
            var publishers = await _publisherService.GetAllPublishersAsync();
            return Ok(publishers);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePublisher([FromBody] UpdatePublisherRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedPublisher = await _publisherService.UpdatePublisherAsync(request.Publisher);
                return Ok(updatedPublisher);
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
        public async Task<IActionResult> DeletePublisher(Guid id)
        {
            try
            {
                await _publisherService.DeletePublisherAsync(id);
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
        [HttpGet("{companyName}/games")]
        public async Task<IActionResult> GetGamesByPublisherName(string companyName)
        {
            try
            {
                var games = await _publisherService.GetGamesByPublisherNameAsync(companyName);
                return Ok(games);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

}
