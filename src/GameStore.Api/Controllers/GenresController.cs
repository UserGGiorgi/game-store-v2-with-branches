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
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IValidator<CreateGenreRequestDto> _createValidator;
        private readonly IValidator<UpdateGenreRequestDto> _updateValidator;
        private readonly ILogger<GamesController> _logger;
        public GenresController(
            IGenreService genreService,
            IValidator<CreateGenreRequestDto> createValidator,
            IValidator<UpdateGenreRequestDto> updateValidator,
            ILogger<GamesController> logger)
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
            _logger.LogInformation("Creating new genre: {GameName}", request.Genre.Name);
            var validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for genre creation: {Errors}", validationResult.Errors);
                return BadRequest(validationResult.ToDictionary());
            }

            try
            {
                var createdGenre = await _genreService.CreateGenreAsync(request);
                _logger.LogInformation("genre created successfully. Key: {Genre}", createdGenre.Name);
                return CreatedAtAction(nameof(GetGenreById), new { id = createdGenre.Id }, createdGenre);
            }
            catch (BadRequestException ex)
            {
                _logger.LogError(ex, "Bad request creating genre: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GenreDetailsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGenreById(Guid id,
        CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching genre by ID: {genreId}", id);
            try
            {
                var genre = await _genreService.GetGenreByIdAsync(id);
                _logger.LogDebug("Retrieved genre: {@Genre}", genre);
                return Ok(genre);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GenreListDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllGenres(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all genres");
            var genres = await _genreService.GetAllGenresAsync();
            return Ok(genres);
        }

        [HttpGet("{id}/genres")]
        [ProducesResponseType(typeof(IEnumerable<GenreListDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSubGenres(Guid id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all subGenres");
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
            _logger.LogInformation("Updating genre: {GenreName}", request.Genre.Name);
            _logger.LogDebug("Update request: {@Request}", request);
            var validationResult = await _updateValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for genre update: {Errors}", validationResult.Errors);
                return BadRequest(validationResult.ToDictionary());
            }
            try
            {
                var updatedGenre = await _genreService.UpdateGenreAsync(request);
                return Ok(updatedGenre);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "genre not found during update: {GenreName}", request.Genre.Name);
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                _logger.LogError(ex, "Bad request updating genre : {GenreName}", request.Genre.Name);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteGenre(Guid id,
        CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleting genre: {GenreId}", id);
            try
            {
                await _genreService.DeleteGenreAsync(id);
                _logger.LogInformation("genre deleted successfully. id: {GenreId}", id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "genre not found during deletion: {GenreId}", id);
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                _logger.LogError(ex, "bad request during deleting genre: {GenreId}", id);
                return BadRequest(ex.Message);
            }
        }
    }
}
