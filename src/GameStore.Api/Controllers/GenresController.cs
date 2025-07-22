using FluentValidation;
using GameStore.Application.Dtos.Genres.CreateGenre;
using GameStore.Application.Dtos.Genres.GetGenre;
using GameStore.Application.Dtos.Genres.UpdateGenre;
using GameStore.Application.Dtos.Platforms.CreatePlatform;
using GameStore.Application.Dtos.Platforms.UpdatePlatform;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GameStore.Web.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IValidator<CreateGenreRequestDto> _createValidator;
        private readonly IValidator<UpdateGenreRequestDto> _updateValidator;
        private readonly ILogger<GenresController> _logger;
        public GenresController(
            IGenreService genreService,
            IValidator<CreateGenreRequestDto> createValidator,
            IValidator<UpdateGenreRequestDto> updateValidator,
            ILogger<GenresController> logger)
        {
            _genreService = genreService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(GenreResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreRequestDto request,
        CancellationToken cancellationToken)
        {
            var validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for genre creation: {Errors}", validationResult.Errors);
                return BadRequest(validationResult.ToDictionary());
            }

            var createdGenre = await _genreService.CreateGenreAsync(request);
            _logger.LogInformation("genre created successfully. Key: {Genre}", createdGenre.Name);
            var genres = await _genreService.GetAllGenresAsync();
            return CreatedAtAction(nameof(GetAllGenres), genres);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GenreDetailsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGenreById(Guid id,
        CancellationToken cancellationToken)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            _logger.LogDebug("Retrieved genre: {@Genre}", genre);
            return Ok(genre);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GenreListDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllGenres(CancellationToken cancellationToken)
        {
            var genres = await _genreService.GetAllGenresAsync();
            return Ok(genres);
        }

        [HttpGet("/games/{key}/genres")]
        [ProducesResponseType(typeof(IEnumerable<GenreListDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGenresByGameKey(
        string key,
        CancellationToken cancellationToken)
        {
            var genres = await _genreService.GetGenresByGameKeyAsync(key);
            _logger.LogInformation("Found {GenreCount} genres for game {GameKey}",
                genres.Count(), key);
            return Ok(genres);
        }

        [HttpGet("{id}/genres")]
        [ProducesResponseType(typeof(IEnumerable<GenreListDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSubGenres(Guid id, CancellationToken cancellationToken)
        {
            var subGenres = await _genreService.GetSubGenresAsync(id);
            return Ok(subGenres);
        }

        [HttpPut]
        [ProducesResponseType(typeof(GenreDetailsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateGenre([FromBody] UpdateGenreRequestDto request,
        CancellationToken cancellationToken)
        {
            var validationResult = await _updateValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for genre update: {Errors}", validationResult.Errors);
                return BadRequest(validationResult.ToDictionary());
            }

            var updatedGenre = await _genreService.UpdateGenreAsync(request);
            _logger.LogInformation("genre updated successfully. Key: {Genre}", updatedGenre.Name);
            var genres = await _genreService.GetAllGenresAsync();
            return CreatedAtAction(nameof(GetAllGenres), genres);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteGenre(Guid id,
        CancellationToken cancellationToken)
        {

            await _genreService.DeleteGenreAsync(id);
            _logger.LogInformation("genre deleted successfully. id: {GenreId}", id);
            return NoContent();
        }
    }
}
