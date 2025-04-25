using GameStore.Application.Dtos.Publisher;
using GameStore.Application.Interfaces;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Web.Controller
{
    [ApiController]
    [Route("publishers")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublisher([FromBody] CreatePublisherRequestDto request)
        {
            var publisherDto = await _publisherService.CreatePublisherAsync(request.Publisher);
            return CreatedAtAction(nameof(GetPublisher), new { id = publisherDto.Id }, publisherDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisher(Guid id)
        {
            return Ok();
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
