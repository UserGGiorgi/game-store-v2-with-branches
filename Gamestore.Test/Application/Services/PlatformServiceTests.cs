using AutoMapper;
using GameStore.Application.Dtos.Platforms.CreatePlatform;
using GameStore.Application.Dtos.Platforms.GetPlatform;
using GameStore.Application.Services.Games;
using GameStore.Domain.Entities.Games;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace Gamestore.Test.Application.Services
{
    public class PlatformServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
        private readonly Mock<IMapper> _mockMapper = new();
        private readonly Mock<ILogger<PlatformService>> _mockLogger;
        private readonly PlatformService _platformService;

        public PlatformServiceTests()
        {
            _mockLogger = new Mock<ILogger<PlatformService>>();
            _platformService = new PlatformService(
                unitOfWork: _mockUnitOfWork.Object,
                mapper: _mockMapper.Object,
                logger: _mockLogger.Object
            );
        }

        [Fact]
        public async Task CreatePlatformAsync_ThrowsBadRequest_WhenTypeExists()
        {
            // Arrange
            var request = new CreatePlatformRequestDto
            {
                Platform = new PlatformDto { Type = "ExistingType" }
            };

            var existingPlatform = new GameStore.Domain.Entities.Games.Platform { Id = Guid.NewGuid(), Type = "ExistingType" };

            _mockUnitOfWork.Setup(u => u.PlatformRepository.GetByNameAsync(request.Platform.Type))
                .ReturnsAsync(existingPlatform);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<BadRequestException>(() =>
                _platformService.CreatePlatformAsync(request));

            Assert.Equal("Platform type must be unique", exception.Message);
        }

        [Fact]
        public async Task CreatePlatformAsync_CreatesPlatform_WhenTypeIsUnique()
        {
            // Arrange
            var request = new CreatePlatformRequestDto
            {
                Platform = new PlatformDto { Type = "NewType" }
            };

            var newPlatform = new GameStore.Domain.Entities.Games.Platform
            {
                Id = Guid.NewGuid(),
                Type = request.Platform.Type
            };

            var expectedDto = new PlatformResponseDto
            {
                Id = newPlatform.Id,
                Type = newPlatform.Type
            };

            _mockUnitOfWork.Setup(u => u.PlatformRepository.GetByNameAsync(request.Platform.Type))
                .ReturnsAsync((GameStore.Domain.Entities.Games.Platform?)null!);

            _mockUnitOfWork.Setup(u => u.PlatformRepository.AddAsync(It.IsAny<GameStore.Domain.Entities.Games.Platform>()))
                .Callback<GameStore.Domain.Entities.Games.Platform>(p => p.Id = newPlatform.Id);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            _mockMapper.Setup(m => m.Map<PlatformResponseDto>(It.Is<GameStore.Domain.Entities.Games.Platform>(p =>
                p.Type == request.Platform.Type)))
                .Returns(expectedDto);

            // Act
            var result = await _platformService.CreatePlatformAsync(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDto.Id, result.Id);
            Assert.Equal(expectedDto.Type, result.Type);

            // Verify repository interactions
            _mockUnitOfWork.Verify(u =>
                u.PlatformRepository.AddAsync(It.Is<GameStore.Domain.Entities.Games.Platform>(p =>
                    p.Type == request.Platform.Type)),
                Times.Once);

            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
        }
        [Fact]
        public async Task GetPlatformByIdAsync_ReturnsPlatform_WhenPlatformExists()
        {
            // Arrange
            var platformId = Guid.NewGuid();
            var platform = new GameStore.Domain.Entities.Games.Platform
            {
                Id = platformId,
                Type = "PC"
            };

            var expectedDto = new PlatformResponseDto
            {
                Id = platformId,
                Type = "PC"
            };

            _mockUnitOfWork.Setup(u => u.PlatformRepository.GetByIdAsync(platformId))
                .ReturnsAsync(platform);

            _mockMapper.Setup(m => m.Map<PlatformResponseDto>(platform))
                .Returns(expectedDto);

            // Act
            var result = await _platformService.GetPlatformByIdAsync(platformId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDto.Id, result.Id);
            Assert.Equal(expectedDto.Type, result.Type);
        }

        [Fact]
        public async Task GetPlatformByIdAsync_ThrowsNotFound_WhenPlatformNotExists()
        {
            // Arrange
            var platformId = Guid.NewGuid();

            _mockUnitOfWork.Setup(u => u.PlatformRepository.GetByIdAsync(platformId))
                .ReturnsAsync((GameStore.Domain.Entities.Games.Platform?)null!);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
                _platformService.GetPlatformByIdAsync(platformId));

            Assert.Equal("Platform not found", exception.Message);
        }
        [Fact]
        public async Task GetAllPlatformsAsync_ReturnsOrderedPlatforms_WhenPlatformsExist()
        {
            // Arrange
            var platforms = new List<GameStore.Domain.Entities.Games.Platform>
    {
        new GameStore.Domain.Entities.Games.Platform { Id = Guid.NewGuid(), Type = "PlayStation" },
        new GameStore.Domain.Entities.Games.Platform { Id = Guid.NewGuid(), Type = "Xbox" },
        new GameStore.Domain.Entities.Games.Platform { Id = Guid.NewGuid(), Type = "PC" }
    };

            var expectedDtos = new List<PlatformResponseDto>
    {
        new PlatformResponseDto { Id = platforms[2].Id, Type = "PC" },
        new PlatformResponseDto { Id = platforms[0].Id, Type = "PlayStation" },
        new PlatformResponseDto { Id = platforms[1].Id, Type = "Xbox" }
    };

            _mockUnitOfWork.Setup(u => u.PlatformRepository.GetAllAsync())
                .ReturnsAsync(platforms);

            _mockMapper.Setup(m => m.Map<IEnumerable<PlatformResponseDto>>(It.IsAny<IEnumerable<GameStore.Domain.Entities.Games.Platform>>()))
        .Returns(expectedDtos);

            // Act
            var result = (await _platformService.GetAllPlatformsAsync()).ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal("PC", result[0].Type);
            Assert.Equal("PlayStation", result[1].Type);
            Assert.Equal("Xbox", result[2].Type);
        }

        [Fact]
        public async Task GetAllPlatformsAsync_ReturnsEmptyList_WhenNoPlatformsExist()
        {
            // Arrange
            var emptyPlatforms = new List<GameStore.Domain.Entities.Games.Platform>();
            var emptyDtos = new List<PlatformResponseDto>();

            _mockUnitOfWork.Setup(u => u.PlatformRepository.GetAllAsync())
                .ReturnsAsync(emptyPlatforms);

            _mockMapper.Setup(m => m.Map<IEnumerable<PlatformResponseDto>>(emptyPlatforms))
                .Returns(emptyDtos);

            // Act
            var result = await _platformService.GetAllPlatformsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
        [Fact]
        public async Task GetPlatformsByGameKeyAsync_ThrowsNotFound_WhenPlatformsNull()
        {
            // Arrange
            const string gameKey = "invalid-key";

            _mockUnitOfWork.Setup(u => u.PlatformRepository.GetPlatformsByGameKeyAsync(gameKey))
                .ReturnsAsync((IEnumerable<GameStore.Domain.Entities.Games.Platform>?)null!);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
                _platformService.GetPlatformsByGameKeyAsync(gameKey));

            Assert.Equal("No platforms found for the specified game key", exception.Message);
        }

        [Fact]
        public async Task GetPlatformsByGameKeyAsync_ReturnsPlatforms_WhenPlatformsExist()
        {
            // Arrange
            const string gameKey = "valid-game";
            var platforms = new List<GameStore.Domain.Entities.Games.Platform>
    {
        new GameStore.Domain.Entities.Games.Platform { Id = Guid.NewGuid(), Type = "PC" },
        new GameStore.Domain.Entities.Games.Platform { Id = Guid.NewGuid(), Type = "Xbox" }
    };

            var expectedDtos = new List<PlatformResponseDto>
    {
        new PlatformResponseDto { Id = platforms[0].Id, Type = "PC" },
        new PlatformResponseDto { Id = platforms[1].Id, Type = "Xbox" }
    };

            _mockUnitOfWork.SetupSequence(u => u.PlatformRepository.GetPlatformsByGameKeyAsync(gameKey))
                .ReturnsAsync(platforms)
                .ReturnsAsync(platforms);

            _mockMapper.Setup(m => m.Map<IEnumerable<PlatformResponseDto>>(platforms))
                .Returns(expectedDtos);

            // Act
            var result = (await _platformService.GetPlatformsByGameKeyAsync(gameKey)).ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("PC", result[0].Type);
            Assert.Equal("Xbox", result[1].Type);
        }

        [Fact]
        public async Task GetPlatformsByGameKeyAsync_ReturnsEmptyList_WhenNoPlatforms()
        {
            // Arrange
            const string gameKey = "game-without-platforms";
            var emptyPlatforms = new List<GameStore.Domain.Entities.Games.Platform>();
            var emptyDtos = new List<PlatformResponseDto>();

            _mockUnitOfWork.SetupSequence(u => u.PlatformRepository.GetPlatformsByGameKeyAsync(gameKey))
                .ReturnsAsync(emptyPlatforms)
                .ReturnsAsync(emptyPlatforms);

            _mockMapper.Setup(m => m.Map<IEnumerable<PlatformResponseDto>>(emptyPlatforms))
                .Returns(emptyDtos);

            // Act
            var result = await _platformService.GetPlatformsByGameKeyAsync(gameKey);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
        [Fact]
        public async Task DeletePlatformAsync_ThrowsNotFound_WhenPlatformNotExists()
        {
            // Arrange
            var platformId = Guid.NewGuid();

            _mockUnitOfWork.Setup(u => u.PlatformRepository.GetByIdAsync(platformId))
                .ReturnsAsync((GameStore.Domain.Entities.Games.Platform?)null!);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
                _platformService.DeletePlatformAsync(platformId));

            Assert.Equal("Platform not found", exception.Message);
        }

        [Fact]
        public async Task DeletePlatformAsync_ThrowsBadRequest_WhenPlatformHasGames()
        {
            // Arrange
            var platformId = Guid.NewGuid();
            var platformType = "PC";

            var game = new Game
            {
                Name = "Test Game",
                Key = "test-game",
            };

            var platform = new GameStore.Domain.Entities.Games.Platform
            {
                Id = platformId,
                Type = platformType,
                Games = new List<GamePlatform>  
        {
            new GamePlatform { Game = game }
        }
            };

            _mockUnitOfWork.Setup(u => u.PlatformRepository.GetByIdAsync(platformId))
                .ReturnsAsync(platform);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<BadRequestException>(() =>
                _platformService.DeletePlatformAsync(platformId));

            Assert.Equal("Cannot delete platform associated with games", exception.Message);
        }

        [Fact]
        public async Task DeletePlatformAsync_DeletesPlatform_WhenNoAssociatedGames()
        {
            // Arrange
            var platformId = Guid.NewGuid();
            var platformType = "PC";
            var platform = new GameStore.Domain.Entities.Games.Platform
            {
                Id = platformId,
                Type = platformType,
                Games = new List<GamePlatform>()
            };

            _mockUnitOfWork.Setup(u => u.PlatformRepository.GetByIdAsync(platformId))
                .ReturnsAsync(platform);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            await _platformService.DeletePlatformAsync(platformId);

            // Assert
            _mockUnitOfWork.Verify(u =>
                u.PlatformRepository.Delete(platform), Times.Once);

            _mockUnitOfWork.Verify(u =>
                u.SaveChangesAsync(), Times.Once);
        }
    }
}
