using AutoMapper;
using GameStore.Application.Dtos.Games.CreateGames;
using GameStore.Application.Dtos.Games.GetGames;
using GameStore.Application.Services;
using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Exceptions;

namespace Gamestore.Test.Application.Services
{
    public class GameServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly GameService _gameService;

        public GameServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _gameService = new GameService(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task CreateGameAsync_ThrowsBadRequest_WhenKeyExists()
        {
            var request = new CreateGameRequestDto
            {
                Game = new GameDto
                {
                    Key = "existing-key",
                    Name = "Existing Game"
                },
                Genres = new List<Guid> { Guid.NewGuid() },
                Platforms = new List<Guid> { Guid.NewGuid() }
            };

            var existingGame = new Game
            {
                Key = "existing-key",
                Name = "Existing Game",
                Description = "Test Description",
                Id = Guid.NewGuid()
            };

            _mockUnitOfWork.Setup(u => u.GameRepository.GetByKeyAsync(request.Game.Key))
                .ReturnsAsync(existingGame);

            await Assert.ThrowsAsync<BadRequestException>(() =>
                _gameService.CreateGameAsync(request));
        }

        [Fact]
        public async Task CreateGameAsync_ThrowsBadRequest_WhenInvalidGenres()
        {
            var request = new CreateGameRequestDto
            {
                Game = new GameDto
                {
                    Key = "new-key",
                    Name = "Test Game"
                },
                Genres = new List<Guid> { Guid.NewGuid() },
                Platforms = new List<Guid> { Guid.NewGuid() }
            };

            _mockUnitOfWork.Setup(u => u.GameRepository.GetByKeyAsync(request.Game.Key))
                .ReturnsAsync((Game?)null!);

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetAllAsync())
                .ReturnsAsync(new List<Genre>());

            await Assert.ThrowsAsync<BadRequestException>(() =>
                _gameService.CreateGameAsync(request));
        }

        [Fact]
        public async Task CreateGameAsync_ThrowsBadRequest_WhenInvalidPlatforms()
        {
            var request = new CreateGameRequestDto
            {
                Game = new GameDto { Key = "new-key" },
                Genres = new List<Guid> { Guid.NewGuid() },
                Platforms = new List<Guid> { Guid.NewGuid() }
            };

            _mockUnitOfWork.Setup(u => u.GameRepository.GetByKeyAsync(request.Game.Key))
                .ReturnsAsync((Game)null!);

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetAllAsync())
                .ReturnsAsync(new List<Genre> { new Genre { Id = request.Genres.First(),
                Name = "Test Genre" } });

            _mockUnitOfWork.Setup(u => u.PlatformRepository.GetAllAsync())
                .ReturnsAsync(new List<Platform>());

            await Assert.ThrowsAsync<BadRequestException>(() =>
                _gameService.CreateGameAsync(request));
        }

        [Fact]
        public async Task CreateGameAsync_ReturnsGameDto_WhenRequestIsValid()
        {
            var request = new CreateGameRequestDto
            {
                Game = new GameDto
                {
                    Key = "valid-key",
                    Name = "Valid Game",
                    Description = "Test Description"
                },
                Genres = new List<Guid> { Guid.NewGuid() },
                Platforms = new List<Guid> { Guid.NewGuid() }
            };

            var validGenre = new Genre
            {
                Id = request.Genres.First(),
                Name = "Test Genre"
            };

            var validPlatform = new Platform
            {
                Id = request.Platforms.First(),
                Type = "TestPlatformType"
            };

            _mockUnitOfWork.Setup(u => u.GameRepository.GetByKeyAsync(request.Game.Key))
                .ReturnsAsync((Game)null!);

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetAllAsync())
                .ReturnsAsync(new List<Genre> { validGenre });

            _mockUnitOfWork.Setup(u => u.PlatformRepository.GetAllAsync())
                .ReturnsAsync(new List<Platform> { validPlatform });

            _mockUnitOfWork.Setup(u => u.CommitAsync())
                .ReturnsAsync(1);

            var result = await _gameService.CreateGameAsync(request);

            Assert.NotNull(result);
            Assert.Equal(request.Game.Key, result.Key);
            Assert.Equal(request.Game.Name, result.Name);
            Assert.Equal(request.Game.Description, result.Description);

            _mockUnitOfWork.Verify(u => u.GameRepository.AddAsync(It.Is<Game>(g =>
                g.Key == request.Game.Key &&
                g.Name == request.Game.Name &&
                g.Description == request.Game.Description &&
                g.Genres.Count == 1 &&
                g.Platforms.Count == 1)),
                Times.Once);

            _mockUnitOfWork.Verify(u => u.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task CreateGameAsync_MapsRelationshipsCorrectly()
        {
            var request = new CreateGameRequestDto
            {
                Game = new GameDto { Key = "valid-key" },
                Genres = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() },
                Platforms = new List<Guid> { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() }
            };

            var validGenres = request.Genres.Select(id => new Genre { Id = id, Name = "Test Genre" }).ToList();
            var validPlatforms = request.Platforms.Select(id => new Platform
            {
                Id = id,
                Type = "Test Platform"
            }).ToList();

            _mockUnitOfWork.Setup(u => u.GameRepository.GetByKeyAsync(request.Game.Key))
                .ReturnsAsync((Game)null!);

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetAllAsync())
                .ReturnsAsync(validGenres);

            _mockUnitOfWork.Setup(u => u.PlatformRepository.GetAllAsync())
                .ReturnsAsync(validPlatforms);

            _mockUnitOfWork.Setup(u => u.CommitAsync())
                .ReturnsAsync(1);

            var result = await _gameService.CreateGameAsync(request);

            _mockUnitOfWork.Verify(u => u.GameRepository.AddAsync(It.Is<Game>(g =>
                g.Genres.Count == request.Genres.Count &&
                g.Platforms.Count == request.Platforms.Count)),
                Times.Once);
        }
        [Fact]
        public async Task GetGameByKeyAsync_ReturnsGame_WhenGameExists()
        {
            // Arrange
            const string testKey = "test-key";
            var testGame = new Game
            {
                Id = Guid.NewGuid(),
                Key = testKey,
                Name = "Test Game",
                Description = "Test Description"
            };

            var expectedDto = new GameResponseDto
            {
                Id = testGame.Id,
                Key = testKey,
                Name = "Test Game",
                Description = "Test Description"
            };

            _mockUnitOfWork.Setup(u => u.GameRepository.GetByKeyAsync(testKey))
                .ReturnsAsync(testGame);

            _mockMapper.Setup(m => m.Map<GameResponseDto>(testGame))
                .Returns(expectedDto);

            // Act
            var result = await _gameService.GetGameByKeyAsync(testKey);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDto.Id, result.Id);
            Assert.Equal(expectedDto.Key, result.Key);
            Assert.Equal(expectedDto.Name, result.Name);
            Assert.Equal(expectedDto.Description, result.Description);
        }

        [Fact]
        public async Task GetGameByKeyAsync_ReturnsNull_WhenGameNotFound()
        {
            // Arrange
            const string nonExistingKey = "non-existing-key";

            _mockUnitOfWork.Setup(u => u.GameRepository.GetByKeyAsync(nonExistingKey))
                .ReturnsAsync((Game?)null!);

            // Act
            var result = await _gameService.GetGameByKeyAsync(nonExistingKey);

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task GetGameByIdAsync_ReturnsGame_WhenGameExists()
        {
            // Arrange
            var testId = Guid.NewGuid();
            var testGame = new Game
            {
                Id = testId,
                Key = "test-key",
                Name = "Test Game",
                Description = "Test Description"
            };

            var expectedDto = new GameResponseDto
            {
                Id = testId,
                Key = "test-key",
                Name = "Test Game",
                Description = "Test Description"
            };

            _mockUnitOfWork.Setup(u => u.GameRepository.GetByIdAsync(testId))
                .ReturnsAsync(testGame);

            _mockMapper.Setup(m => m.Map<GameResponseDto>(testGame))
                .Returns(expectedDto);

            // Act
            var result = await _gameService.GetGameByIdAsync(testId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDto.Id, result.Id);
            Assert.Equal(expectedDto.Key, result.Key);
            Assert.Equal(expectedDto.Name, result.Name);
            Assert.Equal(expectedDto.Description, result.Description);
        }

        [Fact]
        public async Task GetGameByIdAsync_ReturnsNull_WhenGameNotFound()
        {
            // Arrange
            var nonExistingId = Guid.NewGuid();

            _mockUnitOfWork.Setup(u => u.GameRepository.GetByIdAsync(nonExistingId))
                .ReturnsAsync((Game?)null!);

            // Act
            var result = await _gameService.GetGameByIdAsync(nonExistingId);

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task GetGamesByPlatformAsync_ReturnsGames_WhenPlatformHasGames()
        {
            // Arrange
            var platformId = Guid.NewGuid();
            var testGames = new List<Game>
    {
        new Game { Id = Guid.NewGuid(), Key = "game1", Name = "Game 1" },
        new Game { Id = Guid.NewGuid(), Key = "game2", Name = "Game 2" }
    };

            var expectedDtos = testGames.Select(g => new GameResponseDto
            {
                Id = g.Id,
                Key = g.Key,
                Name = g.Name
            }).ToList();

            _mockUnitOfWork.Setup(u => u.GameRepository.GetGamesByPlatformAsync(platformId))
                .ReturnsAsync(testGames);

            _mockMapper.Setup(m => m.Map<IEnumerable<GameResponseDto>>(testGames))
                .Returns(expectedDtos);

            // Act
            var result = (await _gameService.GetGamesByPlatformAsync(platformId)).ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal(expectedDtos[0].Id, result[0].Id);
            Assert.Equal(expectedDtos[1].Name, result[1].Name);
        }

        [Fact]
        public async Task GetGamesByPlatformAsync_ReturnsEmptyList_WhenNoGamesFound()
        {
            // Arrange
            var platformId = Guid.NewGuid();
            var emptyGamesList = new List<Game>();

            _mockUnitOfWork.Setup(u => u.GameRepository.GetGamesByPlatformAsync(platformId))
                .ReturnsAsync(emptyGamesList);

            _mockMapper.Setup(m => m.Map<IEnumerable<GameResponseDto>>(emptyGamesList))
                .Returns(new List<GameResponseDto>());

            // Act
            var result = await _gameService.GetGamesByPlatformAsync(platformId);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
        [Fact]
        public async Task GetGamesByGenreAsync_ReturnsGames_WhenGenreHasGames()
        {
            // Arrange
            var genreId = Guid.NewGuid();
            var testGames = new List<Game>
    {
        new Game { Id = Guid.NewGuid(), Key = "action-game1", Name = "Action Game 1" },
        new Game { Id = Guid.NewGuid(), Key = "action-game2", Name = "Action Game 2" }
    };

            var expectedDtos = testGames.Select(g => new GameResponseDto
            {
                Id = g.Id,
                Key = g.Key,
                Name = g.Name
            }).ToList();

            _mockUnitOfWork.Setup(u => u.GameRepository.GetGamesByGenreAsync(genreId))
                .ReturnsAsync(testGames);

            _mockMapper.Setup(m => m.Map<IEnumerable<GameResponseDto>>(testGames))
                .Returns(expectedDtos);

            // Act
            var result = (await _gameService.GetGamesByGenreAsync(genreId)).ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal(expectedDtos[0].Id, result[0].Id);
            Assert.Equal(expectedDtos[1].Name, result[1].Name);
        }

        [Fact]
        public async Task GetGamesByGenreAsync_ReturnsEmptyList_WhenNoGamesFound()
        {
            // Arrange
            var genreId = Guid.NewGuid();
            var emptyGamesList = new List<Game>();

            _mockUnitOfWork.Setup(u => u.GameRepository.GetGamesByGenreAsync(genreId))
                .ReturnsAsync(emptyGamesList);

            _mockMapper.Setup(m => m.Map<IEnumerable<GameResponseDto>>(emptyGamesList))
                .Returns(Enumerable.Empty<GameResponseDto>());

            var result = await _gameService.GetGamesByGenreAsync(genreId);

            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }

}