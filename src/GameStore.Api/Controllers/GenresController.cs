using FluentValidation;
using GameStore.Application.Dtos.Genres.CreateGenre;
using GameStore.Application.Dtos.Genres.UpdateGenre;
using GameStore.Application.Dtos.Platforms.CreatePlatform;
using GameStore.Application.Dtos.Platforms.UpdatePlatform;
using GameStore.Application.Interfaces;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Web.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IValidator<CreateGenreRequestDto> _createValidator;
        private readonly IValidator<UpdateGenreRequestDto> _updateValidator;
        public GenresController(
            IGenreService genreService,
            IValidator<CreateGenreRequestDto> createValidator,
            IValidator<UpdateGenreRequestDto> updateValidator)
        {
            _genreService = genreService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreRequestDto request)
        {
            var validationResult = await _createValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            try
            {
                var createdGenre = await _genreService.CreateGenreAsync(request);
                return CreatedAtAction(nameof(GetGenreById), new { id = createdGenre.Id }, createdGenre);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(Guid id)
        {
            try
            {
                var genre = await _genreService.GetGenreByIdAsync(id);
                return Ok(genre);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _genreService.GetAllGenresAsync();
            return Ok(genres);
        }

        [HttpGet("{id}/genres")]
        public async Task<IActionResult> GetSubGenres(Guid id)
        {
            var subGenres = await _genreService.GetSubGenresAsync(id);
            return Ok(subGenres);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateGenre([FromBody] UpdateGenreRequestDto request)
        {
            var validationResult = await _updateValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }
            try
            {
                var updatedGenre = await _genreService.UpdateGenreAsync(request);
                return Ok(updatedGenre);
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
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            try
            {
                await _genreService.DeleteGenreAsync(id);
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
