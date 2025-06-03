using FluentValidation;
using FluentValidation.Results;
using GameStore.Application.Dtos.Games.CreateGames;
using GameStore.Application.Dtos.Games.GetGames;
using GameStore.Application.Dtos.Games.UpdateGames;
using GameStore.Application.Interfaces;
using GameStore.Domain.Exceptions;
using GameStore.Web.Controller;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamestore.Test.Api.Controller
{
    public class GamesControllerTests : IClassFixture<GamesControllerFixture>
    {
        private readonly GamesControllerFixture _fixture;

        public GamesControllerTests(GamesControllerFixture fixture)
        {
            _fixture = fixture;
            _fixture.MockGameService.Reset();
            _fixture.MockCreateValidator.Reset();
            _fixture.MockUpdateValidator.Reset();
        }

        [Fact]
        public async Task CreateGame_WhenValidationFails_ReturnsBadRequest()
        {
            var request = new CreateGameRequestDto
            {
                Game = new GameDto(),
                Genres = new List<Guid>(),
                Platforms = new List<Guid>()
            };

            var validationFailures = new List<ValidationFailure>
            {
                new ValidationFailure("Game.Name", "Name is required"),
                new ValidationFailure("Genres", "At least one genre is required")
            };

            var validationResult = new ValidationResult(validationFailures);

            _fixture.MockCreateValidator
                .Setup(v => v.ValidateAsync(request, It.IsAny<CancellationToken>()))
                .ReturnsAsync(validationResult);

            // Act
            var result = await _fixture.Controller.CreateGame(request, CancellationToken.None);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            var errors = Assert.IsType<Dictionary<string, string[]>>(badRequest.Value);

            Assert.Contains("Game.Name", errors.Keys);
            Assert.Contains("Genres", errors.Keys);
            Assert.Equal("Name is required", errors["Game.Name"][0]);
            Assert.Equal("At least one genre is required", errors["Genres"][0]);
        }

        [Fact]
        public async Task CreateGame_WhenServiceThrowsBadRequest_ReturnsBadRequest()
        {
            // Arrange
            var request = GamesControllerFixture.ValidCreateRequest;
            var validationResult = new ValidationResult();
            const string errorMessage = "Invalid genre provided";

            _fixture.MockCreateValidator
                .Setup(v => v.ValidateAsync(request, It.IsAny<CancellationToken>()))
                .ReturnsAsync(validationResult);

            _fixture.MockGameService
                .Setup(s => s.CreateGameAsync(request))
                .ThrowsAsync(new BadRequestException(errorMessage));

            // Act
            var result = await _fixture.Controller.CreateGame(request, CancellationToken.None);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(errorMessage, badRequest.Value);
        }

        [Fact]
        public async Task CreateGame_WhenValid_ReturnsCreatedAtAction()
        {
            // Arrange
            var request = GamesControllerFixture.ValidCreateRequest;
            var validationResult = new ValidationResult();
            var expectedGame = new GameDto
            {
                Key = "test-key",
                Name = "Test Game",
                Description = "Test description"
            };

            _fixture.MockCreateValidator
                .Setup(v => v.ValidateAsync(request, It.IsAny<CancellationToken>()))
                .ReturnsAsync(validationResult);

            _fixture.MockGameService
                .Setup(s => s.CreateGameAsync(request))
                .ReturnsAsync(expectedGame);

            // Act
            var result = await _fixture.Controller.CreateGame(request, CancellationToken.None);

            // Assert
            var createdAt = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(GamesController.GetByKey), createdAt.ActionName);
            Assert.Equal(expectedGame, createdAt.Value);
            Assert.Equal("test-key", createdAt.RouteValues?["key"]);
        }

        [Fact]
        public async Task CreateGame_WhenKeyInvalid_ReturnsValidationError()
        {
            // Arrange
            var request = GamesControllerFixture.ValidCreateRequest;
            request.Game.Key = "Invalid Key!";

            var validationFailures = new List<ValidationFailure>
            {
                new ValidationFailure("Game.Key", "Key must be lowercase alphanumeric with hyphens")
            };

            var validationResult = new ValidationResult(validationFailures);

            _fixture.MockCreateValidator
                .Setup(v => v.ValidateAsync(request, It.IsAny<CancellationToken>()))
                .ReturnsAsync(validationResult);

            // Act
            var result = await _fixture.Controller.CreateGame(request, CancellationToken.None);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            var errors = Assert.IsType<Dictionary<string, string[]>>(badRequest.Value);

            Assert.Contains("Game.Key", errors.Keys);
            Assert.Equal("Key must be lowercase alphanumeric with hyphens", errors["Game.Key"][0]);
        }

        [Fact]
        public async Task CreateGame_WhenCollectionsInvalid_ReturnsValidationErrors()
        {
            // Arrange
            var request = new CreateGameRequestDto
            {
                Game = new GameDto { Name = "Test", Key = "valid-key" },
                Genres = new List<Guid> { Guid.Empty },
                Platforms = new List<Guid>()
            };

            var validationFailures = new List<ValidationFailure>
            {
                new ValidationFailure("Genres[0]", "Genre ID cannot be empty"),
                new ValidationFailure("Platforms", "At least one platform is required")
            };

            var validationResult = new ValidationResult(validationFailures);

            _fixture.MockCreateValidator
                .Setup(v => v.ValidateAsync(request, It.IsAny<CancellationToken>()))
                .ReturnsAsync(validationResult);

            // Act
            var result = await _fixture.Controller.CreateGame(request, CancellationToken.None);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            var errors = Assert.IsType<Dictionary<string, string[]>>(badRequest.Value);

            Assert.Contains("Genres[0]", errors.Keys);
            Assert.Contains("Platforms", errors.Keys);
        }
        [Fact]
        public async Task GetByKey_WhenGameExists_ReturnsOkWithGame()
        {
            // Arrange
            const string gameKey = "test-game";
            var expectedGame = new GameResponseDto
            {
                Id = Guid.NewGuid(),
                Name = "Test Game",
                Key = gameKey,
                Description = "Test description"
            };

            _fixture.MockGameService
                .Setup(s => s.GetGameByKeyAsync(gameKey))
                .ReturnsAsync(expectedGame);

            // Act
            var result = await _fixture.Controller.GetByKey(gameKey, CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var gameDto = Assert.IsType<GameResponseDto>(okResult.Value);

            Assert.Equal(expectedGame.Id, gameDto.Id);
            Assert.Equal(expectedGame.Name, gameDto.Name);
            Assert.Equal(expectedGame.Key, gameDto.Key);
            Assert.Equal(expectedGame.Description, gameDto.Description);

            // Verify caching attribute
            var cacheAttribute = _fixture.Controller.GetType()
                .GetMethod(nameof(GamesController.GetByKey))?
                .GetCustomAttributes(typeof(ResponseCacheAttribute), true);

            Assert.NotNull(cacheAttribute);
            Assert.Single(cacheAttribute);
            var responseCache = (ResponseCacheAttribute)cacheAttribute[0];
            Assert.Equal(30, responseCache.Duration);
        }

        [Fact]
        public async Task GetByKey_WhenGameDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            const string gameKey = "non-existent-game";

            _fixture.MockGameService
                .Setup(s => s.GetGameByKeyAsync(gameKey))
                .ReturnsAsync((GameResponseDto)null!);

            // Act
            var result = await _fixture.Controller.GetByKey(gameKey, CancellationToken.None);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task GetByKey_WhenKeyIsInvalid_ReturnsNotFound(string invalidKey)
        {
            // Arrange
            _fixture.MockGameService
                .Setup(s => s.GetGameByKeyAsync(invalidKey))
                .ReturnsAsync((GameResponseDto)null!);

            // Act
            var result = await _fixture.Controller.GetByKey(invalidKey, CancellationToken.None);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetByKey_WhenServiceThrowsException_PropagatesException()
        {
            // Arrange
            const string gameKey = "error-game";
            var expectedException = new Exception("Test exception");

            _fixture.MockGameService
                .Setup(s => s.GetGameByKeyAsync(gameKey))
                .ThrowsAsync(expectedException);

            // Act & Assert
            var actualException = await Assert.ThrowsAsync<Exception>(
                () => _fixture.Controller.GetByKey(gameKey, CancellationToken.None));

            Assert.Same(expectedException, actualException);
        }
        [Fact]
        public void GetById_HasCorrectRouteAttribute()
        {
            // Arrange
            var method = typeof(GamesController).GetMethod(nameof(GamesController.GetById));

            // Act
            var httpGetAttribute = method?.GetCustomAttributes(typeof(HttpGetAttribute), true)
                .FirstOrDefault() as HttpGetAttribute;

            // Assert
            Assert.NotNull(httpGetAttribute);
            Assert.Equal("id/{id}", httpGetAttribute.Template);
        }

        [Fact]
        public void GetById_HasCorrectResponseTypeAttributes()
        {
            // Arrange
            var method = typeof(GamesController).GetMethod(nameof(GamesController.GetById));

            // Act
            var producesResponseType200 = method?.GetCustomAttributes(typeof(ProducesResponseTypeAttribute), true)
                .FirstOrDefault(attr => ((ProducesResponseTypeAttribute)attr).StatusCode == 200);

            var producesResponseType404 = method?.GetCustomAttributes(typeof(ProducesResponseTypeAttribute), true)
                .FirstOrDefault(attr => ((ProducesResponseTypeAttribute)attr).StatusCode == 404);

            // Assert
            Assert.NotNull(producesResponseType200);
            Assert.Equal(typeof(GameResponseDto), ((ProducesResponseTypeAttribute)producesResponseType200).Type);
            Assert.NotNull(producesResponseType404);
        }

        [Fact]
        public async Task GetByPlatform_WithGames_ReturnsOkWithGames()
        {
            // Arrange
            var platformId = Guid.NewGuid();
            var expectedGames = new List<GameResponseDto>
            {
            new() { Id = Guid.NewGuid(), Name = "Game 1", Key = "game-1" },
            new() { Id = Guid.NewGuid(), Name = "Game 2", Key = "game-2" }
            };

            _fixture.SetupGameServiceForGetByPlatform(platformId, expectedGames);

            // Act
            var result = await _fixture.Controller.GetByPlatform(platformId, CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var games = Assert.IsAssignableFrom<IEnumerable<GameResponseDto>>(okResult.Value);

            Assert.Equal(2, games.Count());
            Assert.Contains(games, g => g.Name == "Game 1");
            Assert.Contains(games, g => g.Name == "Game 2");
        }

        [Fact]
        public async Task GetByPlatform_WithNoGames_ReturnsOkWithEmptyList()
        {
            // Arrange
            var platformId = Guid.NewGuid();
            var emptyGames = Enumerable.Empty<GameResponseDto>();

            _fixture.SetupGameServiceForGetByPlatform(platformId);

            // Act
            var result = await _fixture.Controller.GetByPlatform(platformId, CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var games = Assert.IsAssignableFrom<IEnumerable<GameResponseDto>>(okResult.Value);

            Assert.Empty(games);
        }

        [Fact]
        public async Task GetByPlatform_WithEmptyPlatformId_ReturnsOkWithEmptyList()
        {
            // Arrange
            var emptyPlatformId = Guid.Empty;
            var emptyGames = Enumerable.Empty<GameResponseDto>();

            _fixture.MockGameService
                .Setup(s => s.GetGamesByPlatformAsync(emptyPlatformId))
                .ReturnsAsync(emptyGames);

            // Act
            var result = await _fixture.Controller.GetByPlatform(emptyPlatformId, CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var games = Assert.IsAssignableFrom<IEnumerable<GameResponseDto>>(okResult.Value);

            Assert.Empty(games);
        }

        [Fact]
        public async Task GetByPlatform_WhenServiceThrowsException_PropagatesException()
        {
            // Arrange
            var platformId = Guid.NewGuid();
            var expectedException = new Exception("Database error");

            _fixture.SetupGameServiceForGetByPlatform(platformId, exception: expectedException);

            // Act & Assert
            var actualException = await Assert.ThrowsAsync<Exception>(
                () => _fixture.Controller.GetByPlatform(platformId, CancellationToken.None));

            Assert.Same(expectedException, actualException);
        }

        [Fact]
        public void GetByPlatform_HasCorrectRouteAttribute()
        {
            // Arrange
            var method = typeof(GamesController).GetMethod(nameof(GamesController.GetByPlatform));

            // Act
            var httpGetAttribute = method?.GetCustomAttributes(typeof(HttpGetAttribute), true)
                .FirstOrDefault() as HttpGetAttribute;

            // Assert
            Assert.NotNull(httpGetAttribute);
            Assert.Equal("platform/{platformId}", httpGetAttribute.Template);
        }

        [Fact]
        public void GetByPlatform_HasCorrectResponseTypeAttributes()
        {
            // Arrange
            var method = typeof(GamesController).GetMethod(nameof(GamesController.GetByPlatform));

            // Act
            var producesResponseType200 = method?.GetCustomAttributes(typeof(ProducesResponseTypeAttribute), true)
                .FirstOrDefault(attr => ((ProducesResponseTypeAttribute)attr).StatusCode == 200);

            // Assert
            Assert.NotNull(producesResponseType200);
            var responseType = ((ProducesResponseTypeAttribute)producesResponseType200).Type;
            Assert.Equal(typeof(IEnumerable<GameResponseDto>), responseType);
        }

        [Fact]
        public void GetByPlatform_HasNoNotFoundResponseAttribute()
        {
            // Arrange
            var method = typeof(GamesController).GetMethod(nameof(GamesController.GetByPlatform));

            // Act
            var producesResponseType404 = method?.GetCustomAttributes(typeof(ProducesResponseTypeAttribute), true)
                .FirstOrDefault(attr => ((ProducesResponseTypeAttribute)attr).StatusCode == 404);

            // Assert
            Assert.Null(producesResponseType404);
        }
        // Add to GamesControllerTests class
        [Fact]
        public async Task GetByGenre_WithGames_ReturnsOkWithGames()
        {
            // Arrange
            var genreId = Guid.NewGuid();
            var expectedGames = new List<GameResponseDto>
            {
            new() { Id = Guid.NewGuid(), Name = "RPG Game", Key = "rpg-game" },
            new() { Id = Guid.NewGuid(), Name = "Adventure Game", Key = "adventure-game" }
            };

            _fixture.SetupGameServiceForGetByGenre(genreId, expectedGames);

            // Act
            var result = await _fixture.Controller.GetByGenre(genreId, CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var games = Assert.IsAssignableFrom<IEnumerable<GameResponseDto>>(okResult.Value);

            Assert.Equal(2, games.Count());
            Assert.Contains(games, g => g.Name == "RPG Game");
            Assert.Contains(games, g => g.Name == "Adventure Game");
        }

        [Fact]
        public async Task GetByGenre_WithNoGames_ReturnsOkWithEmptyList()
        {
            // Arrange
            var genreId = Guid.NewGuid();
            var emptyGames = Enumerable.Empty<GameResponseDto>();

            _fixture.SetupGameServiceForGetByGenre(genreId);

            // Act
            var result = await _fixture.Controller.GetByGenre(genreId, CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var games = Assert.IsAssignableFrom<IEnumerable<GameResponseDto>>(okResult.Value);

            Assert.Empty(games);
        }

        [Fact]
        public async Task GetByGenre_WithEmptyGenreId_ReturnsOkWithEmptyList()
        {
            // Arrange
            var emptyGenreId = Guid.Empty;
            var emptyGames = Enumerable.Empty<GameResponseDto>();

            _fixture.MockGameService
                .Setup(s => s.GetGamesByGenreAsync(emptyGenreId))
                .ReturnsAsync(emptyGames);

            // Act
            var result = await _fixture.Controller.GetByGenre(emptyGenreId, CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var games = Assert.IsAssignableFrom<IEnumerable<GameResponseDto>>(okResult.Value);

            Assert.Empty(games);
        }

        [Fact]
        public async Task GetByGenre_WhenServiceThrowsException_PropagatesException()
        {
            // Arrange
            var genreId = Guid.NewGuid();
            var expectedException = new Exception("Genre service error");

            _fixture.SetupGameServiceForGetByGenre(genreId, exception: expectedException);

            // Act & Assert
            var actualException = await Assert.ThrowsAsync<Exception>(
                () => _fixture.Controller.GetByGenre(genreId, CancellationToken.None));

            Assert.Same(expectedException, actualException);
        }

        [Fact]
        public void GetByGenre_HasCorrectRouteAttribute()
        {
            // Arrange
            var method = typeof(GamesController).GetMethod(nameof(GamesController.GetByGenre));

            // Act
            var httpGetAttribute = method?.GetCustomAttributes(typeof(HttpGetAttribute), true)
                .FirstOrDefault() as HttpGetAttribute;

            // Assert
            Assert.NotNull(httpGetAttribute);
            Assert.Equal("genre/{genreId}", httpGetAttribute.Template);
        }

        [Fact]
        public void GetByGenre_HasCorrectResponseTypeAttributes()
        {
            // Arrange
            var method = typeof(GamesController).GetMethod(nameof(GamesController.GetByGenre));

            // Act
            var producesResponseType200 = method?.GetCustomAttributes(typeof(ProducesResponseTypeAttribute), true)
                .FirstOrDefault(attr => ((ProducesResponseTypeAttribute)attr).StatusCode == 200);

            // Assert
            Assert.NotNull(producesResponseType200);
            var responseType = ((ProducesResponseTypeAttribute)producesResponseType200).Type;
            Assert.Equal(typeof(IEnumerable<GameResponseDto>), responseType);
        }

        [Fact]
        public void GetByGenre_HasNoNotFoundResponseAttribute()
        {
            // Arrange
            var method = typeof(GamesController).GetMethod(nameof(GamesController.GetByGenre));

            // Act
            var producesResponseType404 = method?.GetCustomAttributes(typeof(ProducesResponseTypeAttribute), true)
                .FirstOrDefault(attr => ((ProducesResponseTypeAttribute)attr).StatusCode == 404);

            // Assert
            Assert.Null(producesResponseType404);
        }
        // Add to GamesControllerTests class
        [Fact]
        public async Task Delete_WhenGameExists_ReturnsNoContent()
        {
            // Arrange
            const string gameKey = "existing-game";

            _fixture.SetupGameServiceForDelete(gameKey);

            // Act
            var result = await _fixture.Controller.Delete(gameKey, CancellationToken.None);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_WhenGameNotFound_ReturnsNotFound()
        {
            // Arrange
            const string gameKey = "non-existent-game";
            var expectedException = new NotFoundException($"Game with key '{gameKey}' not found");

            _fixture.SetupGameServiceForDelete(gameKey, expectedException);

            // Act
            var result = await _fixture.Controller.Delete(gameKey, CancellationToken.None);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(expectedException.Message, notFoundResult.Value);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task Delete_WithInvalidKey_ReturnsNotFound(string invalidKey)
        {
            // Arrange
            var expectedException = new NotFoundException($"Game with key '{invalidKey}' not found");

            _fixture.SetupGameServiceForDelete(invalidKey, expectedException);

            // Act
            var result = await _fixture.Controller.Delete(invalidKey, CancellationToken.None);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(expectedException.Message, notFoundResult.Value);
        }

        [Fact]
        public async Task Delete_WhenServiceThrowsUnexpectedException_PropagatesException()
        {
            // Arrange
            const string gameKey = "error-game";
            const string errorMessage = "Database connection failed";
            var expectedException = new Exception(errorMessage);

            _fixture.SetupGameServiceForDelete(gameKey, expectedException);

            // Act & Assert
            var actualException = await Assert.ThrowsAsync<Exception>(
                () => _fixture.Controller.Delete(gameKey, CancellationToken.None));

            Assert.Equal(errorMessage, actualException.Message);
        }

        [Fact]
        public void Delete_HasCorrectRouteAttribute()
        {
            // Arrange
            var method = typeof(GamesController).GetMethod(nameof(GamesController.Delete));

            // Act
            var httpDeleteAttribute = method?.GetCustomAttributes(typeof(HttpDeleteAttribute), true)
                .FirstOrDefault() as HttpDeleteAttribute;

            // Assert
            Assert.NotNull(httpDeleteAttribute);
            Assert.Equal("{key}", httpDeleteAttribute.Template);
        }

        [Fact]
        public void Delete_HasCorrectResponseTypeAttributes()
        {
            // Arrange
            var method = typeof(GamesController).GetMethod(nameof(GamesController.Delete));

            // Act
            var producesResponseType204 = method?.GetCustomAttributes(typeof(ProducesResponseTypeAttribute), true)
                .FirstOrDefault(attr => ((ProducesResponseTypeAttribute)attr).StatusCode == 204);

            var producesResponseType404 = method?.GetCustomAttributes(typeof(ProducesResponseTypeAttribute), true)
                .FirstOrDefault(attr => ((ProducesResponseTypeAttribute)attr).StatusCode == 404);

            // Assert
            Assert.NotNull(producesResponseType204);
            Assert.Equal(typeof(void), ((ProducesResponseTypeAttribute)producesResponseType204).Type);
            Assert.NotNull(producesResponseType404);
        }

        [Fact]
        public async Task Delete_CallsServiceWithCorrectParameters()
        {
            // Arrange
            const string gameKey = "test-game";
            var mockService = new Mock<IGameService>();

            var controller = new GamesController(
                mockService.Object,
                _fixture.MockCreateValidator.Object,
                _fixture.MockUpdateValidator.Object
            );

            // Act
            await controller.Delete(gameKey, CancellationToken.None);

            // Assert
            mockService.Verify(s =>
                s.DeleteGameAsync(gameKey),
                Times.Once
            );
        }
    }
}