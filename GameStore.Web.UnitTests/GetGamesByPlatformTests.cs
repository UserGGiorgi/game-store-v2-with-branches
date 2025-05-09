using GameStore.Application.Dtos.Games;
using GameStore.Application.Interfaces;
using GameStore.Web.Controller;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Web.UnitTests
{
    [TestFixture]
    public class GetGamesByPlatformTests
    {
        private Mock<IGameService> _mockGameService;
        private Mock<IPlatformService> _mockPlatformService;
        private GamesController _controller;

        [SetUp]
        public void Setup()
        {
            _mockGameService = new Mock<IGameService>();
            _mockPlatformService = new Mock<IPlatformService>();
            _controller = new GamesController(
                _mockGameService.Object,
                Mock.Of<IGenreService>(),
                _mockPlatformService.Object);
        }

        [Test]
        public async Task GetGamesByPlatform_WithValidPlatformId_ReturnsOkWithGames()
        {
            // Arrange
            var platformId = Guid.NewGuid();
            var expectedGames = new List<GameResponseDto>
        {
            new GameResponseDto { Id = Guid.NewGuid(), Key = "game1" },
            new GameResponseDto { Id = Guid.NewGuid(), Key = "game2" }
        };

            _mockPlatformService.Setup(x => x.PlatformExistsAsync(platformId))
                .ReturnsAsync(true);

            _mockGameService.Setup(x => x.GetGamesByPlatformAsync(platformId))
                .ReturnsAsync(expectedGames);

            // Act
            var result = await _controller.GetGamesByPlatform(platformId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(expectedGames, okResult.Value);
        }
        [Test]
        public async Task GetGamesByPlatform_WithEmptyPlatformId_ReturnsBadRequest()
        {
            // Arrange
            var emptyPlatformId = Guid.Empty;

            // Act
            var result = await _controller.GetGamesByPlatform(emptyPlatformId);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual("Platform ID cannot be empty", badRequestResult.Value);
        }

    }
}
