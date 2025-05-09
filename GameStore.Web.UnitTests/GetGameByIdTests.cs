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
    public class GetGameByIdTests
    {
        private Mock<IGameService> _mockGameService;
        private GamesController _controller;

        [SetUp]
        public void Setup()
        {
            _mockGameService = new Mock<IGameService>();
            _controller = new GamesController(
                _mockGameService.Object,
                Mock.Of<IGenreService>(),
                Mock.Of<IPlatformService>());
        }

        [Test]
        public async Task GetGameById_WithValidId_ReturnsOkWithGame()
        {
            var testId = Guid.NewGuid();
            var expectedGame = new GameResponseDto { Id = testId, Key = "test-game" };

            _mockGameService.Setup(x => x.GetGameByIdAsync(testId))
                .ReturnsAsync(expectedGame);

            var result = await _controller.GetGameById(testId);

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(expectedGame, okResult.Value);
        }

        [Test]
        public async Task GetGameById_WithNonExistentId_ReturnsNotFound()
        {
            var testId = Guid.NewGuid();

            _mockGameService.Setup(x => x.GetGameByIdAsync(testId))
                .ReturnsAsync((GameResponseDto)null);

            var result = await _controller.GetGameById(testId);

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task GetGameById_CallsServiceWithCorrectId()
        {
            var testId = Guid.NewGuid();

            _mockGameService.Setup(x => x.GetGameByIdAsync(testId))
                .ReturnsAsync(new GameResponseDto());

            await _controller.GetGameById(testId);

            _mockGameService.Verify(x => x.GetGameByIdAsync(testId), Times.Once);
        }

        [Test]
        public async Task GetGameById_WithEmptyGuid_ReturnsBadRequest()
        {
            var emptyId = Guid.Empty;

            var result = await _controller.GetGameById(emptyId);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual("Game ID cannot be empty", badRequestResult.Value);
        }
    }
}
