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
            // Arrange
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
            // Arrange
            var request = new CreateGameRequestDto
            {
                Game = new GameDto { Key = "new-key" },
                Genres = new List<Guid> { Guid.NewGuid() },
                Platforms = new List<Guid> { Guid.NewGuid() }
            };

            _mockUnitOfWork.Setup(u => u.GameRepository.GetByKeyAsync(request.Game.Key))
                .ReturnsAsync((Game)null);

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
                .ReturnsAsync((Game)null);

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
            // Arrange
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
                .ReturnsAsync((Game)null);

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
            // Arrange
            var request = new CreateGameRequestDto
            {
                Game = new GameDto { Key = "valid-key" },
                Genres = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() },
                Platforms = new List<Guid> { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() }
            };

            var validGenres = request.Genres.Select(id => new Genre { Id = id,Name = "Test Genre"}).ToList();
            var validPlatforms = request.Platforms.Select(id => new Platform { Id = id,
                Type = "Test Platform"
            }).ToList();

            _mockUnitOfWork.Setup(u => u.GameRepository.GetByKeyAsync(request.Game.Key))
                .ReturnsAsync((Game)null);

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetAllAsync())
                .ReturnsAsync(validGenres);

            _mockUnitOfWork.Setup(u => u.PlatformRepository.GetAllAsync())
                .ReturnsAsync(validPlatforms);

            _mockUnitOfWork.Setup(u => u.CommitAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _gameService.CreateGameAsync(request);

            // Assert
            _mockUnitOfWork.Verify(u => u.GameRepository.AddAsync(It.Is<Game>(g =>
                g.Genres.Count == request.Genres.Count &&
                g.Platforms.Count == request.Platforms.Count)),
                Times.Once);
        }
    }
}