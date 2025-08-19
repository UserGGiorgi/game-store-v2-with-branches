using AutoMapper;
using GameStore.Application.Dtos.Genres.CreateGenre;
using GameStore.Application.Dtos.Genres.GetGenre;
using GameStore.Application.Services.Games;
using GameStore.Domain.Entities.Games;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace Gamestore.Test.Application.Services
{
    public class GenreServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
        private readonly Mock<IMapper> _mockMapper = new();
        public Mock<ILogger<GenreService>> _mockLogger { get; }
        private readonly GenreService _genreService;

        public GenreServiceTests()
        {
            _mockLogger = new Mock<ILogger<GenreService>>();
            _genreService = new GenreService(_mockUnitOfWork.Object, _mockMapper.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task CreateGenreAsync_ThrowsBadRequest_WhenNameExists()
        {
            // Arrange
            var request = new CreateGenreRequestDto
            {
                Genre = new GenreDto { Name = "Existing Genre" }
            };

            var existingGenre = new Genre { Id = Guid.NewGuid(), Name = "Existing Genre" };

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetByNameAsync(request.Genre.Name))
                .ReturnsAsync(existingGenre);

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() =>
                _genreService.CreateGenreAsync(request));
        }

        [Fact]
        public async Task CreateGenreAsync_ThrowsBadRequest_WhenParentNotFound()
        {
            // Arrange
            var parentId = "valid guid";
            var guid = Guid.NewGuid();
            var request = new CreateGenreRequestDto
            {
                Genre = new GenreDto
                {
                    Name = "New Genre",
                    ParentGenreId = parentId
                }
            };

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetByNameAsync(request.Genre.Name))
                .ReturnsAsync((Genre?)null!);

            _mockUnitOfWork.Setup(u => u.GenreRepository.ExistsAsync(Guid.NewGuid()))
                .ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() =>
                _genreService.CreateGenreAsync(request));
        }

        [Fact]
        public async Task CreateGenreAsync_CreatesGenre_WhenParentExists()
        {
            // Arrange
            var parentId = Guid.NewGuid();
            var parentidString = parentId.ToString();
            var request = new CreateGenreRequestDto
            {
                Genre = new GenreDto
                {
                    Name = "Child Genre",
                    ParentGenreId = parentidString
                }
            };

            var expectedGenre = new Genre
            {
                Id = Guid.NewGuid(),
                Name = request.Genre.Name,
                ParentGenreId = parentId
            };

            var expectedDto = new GenreResponseDto
            {
                Id = expectedGenre.Id,
                Name = expectedGenre.Name,
                ParentGenreId = parentId
            };

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetByNameAsync(request.Genre.Name))
                .ReturnsAsync((Genre?)null!);

            _mockUnitOfWork.Setup(u => u.GenreRepository.ExistsAsync(parentId))
                .ReturnsAsync(true);

            _mockUnitOfWork.Setup(u => u.GenreRepository.AddAsync(It.IsAny<Genre>()))
                .Callback<Genre>(g =>
                {
                    g.Id = expectedGenre.Id; // Simulate ID generation
                });

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            _mockMapper.Setup(m => m.Map<GenreResponseDto>(It.IsAny<Genre>()))
            .Returns(expectedDto);

            // Act
            var result = await _genreService.CreateGenreAsync(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDto.Id, result.Id);
            Assert.Equal(expectedDto.Name, result.Name);
            Assert.Equal(expectedDto.ParentGenreId, result.ParentGenreId);

            // Verify repository interactions
            _mockUnitOfWork.Verify(u =>
                u.GenreRepository.AddAsync(It.Is<Genre>(g =>
                    g.Name == request.Genre.Name &&
                    g.ParentGenreId == parentId)),
                Times.Once);

            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task CreateGenreAsync_CreatesRootGenre_WhenNoParent()
        {
            // Arrange
            var request = new CreateGenreRequestDto
            {
                Genre = new GenreDto
                {
                    Name = "Root Genre",
                    ParentGenreId = null
                }
            };

            var expectedGenre = new Genre
            {
                Id = Guid.NewGuid(),
                Name = request.Genre.Name,
                ParentGenreId = null
            };

            var expectedDto = new GenreResponseDto
            {
                Id = expectedGenre.Id,
                Name = expectedGenre.Name,
                ParentGenreId = null
            };

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetByNameAsync(request.Genre.Name))
                .ReturnsAsync((Genre?)null!);

            // No parent check setup needed when ParentGenreId is null

            _mockUnitOfWork.Setup(u => u.GenreRepository.AddAsync(It.IsAny<Genre>()))
                .Callback<Genre>(g => g.Id = expectedGenre.Id);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            _mockMapper.Setup(m => m.Map<GenreResponseDto>(It.Is<Genre>(g =>
                g.Name == request.Genre.Name && g.ParentGenreId == null)))
                .Returns(expectedDto);

            // Act
            var result = await _genreService.CreateGenreAsync(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDto.Id, result.Id);
            Assert.Equal(expectedDto.Name, result.Name);
            Assert.Null(result.ParentGenreId);

            // Verify no parent existence check was made
            _mockUnitOfWork.Verify(u =>
                u.GenreRepository.ExistsAsync(It.IsAny<Guid>()), Times.Never);
        }
        [Fact]
        public async Task GetGenreByIdAsync_ReturnsGenreDetails_WhenGenreExists()
        {
            // Arrange
            var genreId = Guid.NewGuid();
            var genre = new Genre
            {
                Id = genreId,
                Name = "Action",
                ParentGenreId = null
            };

            var expectedDto = new GenreDetailsDto
            {
                Id = genreId,
                Name = "Action",
                ParentGenreId = null
            };

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetByIdAsync(genreId))
                .ReturnsAsync(genre);

            _mockMapper.Setup(m => m.Map<GenreDetailsDto>(genre))
                .Returns(expectedDto);

            // Act
            var result = await _genreService.GetGenreByIdAsync(genreId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDto.Id, result.Id);
            Assert.Equal(expectedDto.Name, result.Name);
            Assert.Null(result.ParentGenreId);
        }

        [Fact]
        public async Task GetGenreByIdAsync_ThrowsNotFound_WhenGenreNotExists()
        {
            // Arrange
            var genreId = Guid.NewGuid();

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetByIdAsync(genreId))
                .ReturnsAsync((Genre?)null!);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
                _genreService.GetGenreByIdAsync(genreId));

            Assert.Equal("Genre not found", exception.Message);
        }
        [Fact]
        public async Task GetAllGenresAsync_ReturnsGenresOrderedByName_WhenGenresExist()
        {
            // Arrange
            var genres = new List<Genre>
    {
        new Genre { Id = Guid.NewGuid(), Name = "Strategy" },
        new Genre { Id = Guid.NewGuid(), Name = "Action" },
        new Genre { Id = Guid.NewGuid(), Name = "Adventure" }
    };

            var expectedDtos = new List<GenreListDto>
    {
        new GenreListDto { Id = genres[1].Id, Name = "Action" },
        new GenreListDto { Id = genres[2].Id, Name = "Adventure" },
        new GenreListDto { Id = genres[0].Id, Name = "Strategy" }
    };

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetAllAsync())
                .ReturnsAsync(genres);

            _mockMapper.Setup(m => m.Map<IEnumerable<GenreListDto>>(It.Is<IEnumerable<Genre>>(g =>
                g.OrderBy(genre => genre.Name).SequenceEqual(genres.OrderBy(genre => genre.Name)))))
                .Returns(expectedDtos);

            // Act
            var result = (await _genreService.GetAllGenresAsync()).ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal("Action", result[0].Name);
            Assert.Equal("Adventure", result[1].Name);
            Assert.Equal("Strategy", result[2].Name);
        }

        [Fact]
        public async Task GetAllGenresAsync_ReturnsEmptyList_WhenNoGenresExist()
        {
            // Arrange
            var emptyGenreList = new List<Genre>();
            var emptyDtoList = new List<GenreListDto>();

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetAllAsync())
                .ReturnsAsync(emptyGenreList);

            _mockMapper.Setup(m => m.Map<IEnumerable<GenreListDto>>(emptyGenreList))
                .Returns(emptyDtoList);

            // Act
            var result = await _genreService.GetAllGenresAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
        [Fact]
        public async Task GetGenresByGameKeyAsync_ThrowsNotFound_WhenGameNotExists()
        {
            // Arrange
            const string gameKey = "invalid-key";

            _mockUnitOfWork.Setup(u => u.GameRepository.GetByKeyAsync(gameKey))
                .ReturnsAsync((Game?)null!);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
                _genreService.GetGenresByGameKeyAsync(gameKey));

            Assert.Equal("Game not found", exception.Message);
        }

        [Fact]
        public async Task GetGenresByGameKeyAsync_ReturnsGenres_WhenGameExistsWithGenres()
        {
            // Arrange
            const string gameKey = "valid-game";
            const string gameName = "Test Name";
            var game = new Game { Key = gameKey, Name = gameName };

            var genres = new List<Genre>
    {
        new Genre { Id = Guid.NewGuid(), Name = "RPG" },
        new Genre { Id = Guid.NewGuid(), Name = "Adventure" }
    };

            var expectedDtos = new List<GenreListDto>
    {
        new GenreListDto { Id = genres[0].Id, Name = "RPG" },
        new GenreListDto { Id = genres[1].Id, Name = "Adventure" }
    };

            _mockUnitOfWork.Setup(u => u.GameRepository.GetByKeyAsync(gameKey))
                .ReturnsAsync(game);

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetGenresByGameKeyAsync(gameKey))
                .ReturnsAsync(genres);

            _mockMapper.Setup(m => m.Map<IEnumerable<GenreListDto>>(genres))
                .Returns(expectedDtos);

            // Act
            var result = (await _genreService.GetGenresByGameKeyAsync(gameKey)).ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("RPG", result[0].Name);
            Assert.Equal("Adventure", result[1].Name);
        }

        [Fact]
        public async Task GetGenresByGameKeyAsync_ReturnsEmptyList_WhenGameHasNoGenres()
        {
            // Arrange
            const string gameKey = "game-without-genres";
            const string gameName = "Test Name";
            var game = new Game { Key = gameKey , Name = gameName };
            var emptyGenres = new List<Genre>();
            var emptyDtos = new List<GenreListDto>();

            _mockUnitOfWork.Setup(u => u.GameRepository.GetByKeyAsync(gameKey))
                .ReturnsAsync(game);

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetGenresByGameKeyAsync(gameKey))
                .ReturnsAsync(emptyGenres);

            _mockMapper.Setup(m => m.Map<IEnumerable<GenreListDto>>(emptyGenres))
                .Returns(emptyDtos);

            // Act
            var result = await _genreService.GetGenresByGameKeyAsync(gameKey);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
        [Fact]
        public async Task GetSubGenresAsync_ReturnsOrderedSubGenres_WhenSubGenresExist()
        {
            // Arrange
            var parentId = Guid.NewGuid();
            var subGenres = new List<Genre>
    {
        new Genre { Id = Guid.NewGuid(), Name = "MMORPG", ParentGenreId = parentId },
        new Genre { Id = Guid.NewGuid(), Name = "Action RPG", ParentGenreId = parentId },
        new Genre { Id = Guid.NewGuid(), Name = "JRPG", ParentGenreId = parentId }
    };

            var expectedDtos = new List<GenreListDto>
    {
        new GenreListDto { Id = subGenres[1].Id, Name = "Action RPG" },
        new GenreListDto { Id = subGenres[2].Id, Name = "JRPG" },
        new GenreListDto { Id = subGenres[0].Id, Name = "MMORPG" }
    };

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetSubGenresAsync(parentId))
                .ReturnsAsync(subGenres);

            _mockMapper.Setup(m => m.Map<IEnumerable<GenreListDto>>(It.Is<IEnumerable<Genre>>(g =>
                g.SequenceEqual(subGenres.OrderBy(x => x.Name)))))
                .Returns(expectedDtos);

            // Act
            var result = (await _genreService.GetSubGenresAsync(parentId)).ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal("Action RPG", result[0].Name);
            Assert.Equal("JRPG", result[1].Name);
            Assert.Equal("MMORPG", result[2].Name);
        }

        [Fact]
        public async Task GetSubGenresAsync_ReturnsEmptyList_WhenNoSubGenresExist()
        {
            // Arrange
            var parentId = Guid.NewGuid();
            var emptyList = new List<Genre>();
            var emptyDtos = new List<GenreListDto>();

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetSubGenresAsync(parentId))
                .ReturnsAsync(emptyList);

            _mockMapper.Setup(m => m.Map<IEnumerable<GenreListDto>>(emptyList))
                .Returns(emptyDtos);

            // Act
            var result = await _genreService.GetSubGenresAsync(parentId);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task DeleteGenreAsync_ThrowsNotFound_WhenGenreNotExists()
        {
            // Arrange
            var genreId = Guid.NewGuid();

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetByIdAsync(genreId))
                .ReturnsAsync((Genre?)null!);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
                _genreService.DeleteGenreAsync(genreId));

            Assert.Equal("Genre not found", exception.Message);
        }

        [Fact]
        public async Task DeleteGenreAsync_ThrowsBadRequest_WhenGenreHasSubGenres()
        {
            // Arrange
            var genreId = Guid.NewGuid();
            var name = "Test Genre";
            var genre = new Genre { Id = genreId, Name = name };

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetByIdAsync(genreId))
                .ReturnsAsync(genre);

            _mockUnitOfWork.Setup(u => u.GenreRepository.HasSubGenresAsync(genreId))
                .ReturnsAsync(true);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<BadRequestException>(() =>
                _genreService.DeleteGenreAsync(genreId));

            Assert.Equal("Cannot delete genre with sub-genres", exception.Message);
        }

        [Fact]
        public async Task DeleteGenreAsync_ThrowsBadRequest_WhenGenreAttachedToGames()
        {
            // Arrange
            var genreId = Guid.NewGuid();
            var name = "Test Genre";
            var genre = new Genre { Id = genreId, Name = name };

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetByIdAsync(genreId))
                .ReturnsAsync(genre);

            _mockUnitOfWork.Setup(u => u.GenreRepository.HasSubGenresAsync(genreId))
                .ReturnsAsync(false);

            _mockUnitOfWork.Setup(u => u.GenreRepository.IsAttachedToGamesAsync(genreId))
                .ReturnsAsync(true);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<BadRequestException>(() =>
                _genreService.DeleteGenreAsync(genreId));

            Assert.Equal("Cannot delete genre associated with games", exception.Message);
        }

        [Fact]
        public async Task DeleteGenreAsync_DeletesGenre_WhenValidConditions()
        {
            // Arrange
            var genreId = Guid.NewGuid();
            var name = "Test Genre";
            var genre = new Genre { Id = genreId , Name = name };

            _mockUnitOfWork.Setup(u => u.GenreRepository.GetByIdAsync(genreId))
                .ReturnsAsync(genre);

            _mockUnitOfWork.Setup(u => u.GenreRepository.HasSubGenresAsync(genreId))
                .ReturnsAsync(false);

            _mockUnitOfWork.Setup(u => u.GenreRepository.IsAttachedToGamesAsync(genreId))
                .ReturnsAsync(false);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            await _genreService.DeleteGenreAsync(genreId);

            // Assert
            _mockUnitOfWork.Verify(u =>
                u.GenreRepository.Delete(genre), Times.Once);

            _mockUnitOfWork.Verify(u =>
                u.SaveChangesAsync(), Times.Once);
        }
    }
}
