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
    public class GetGameByKeyTests
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
        public async Task GetGameByKey_WhenGameExists_ReturnsOkWithGame()
        {
            var testKey = "test-game";
            var expectedGame = new GameResponseDto { Key = testKey };
            _mockGameService.Setup(x => x.GetGameByKeyAsync(testKey))
                .ReturnsAsync((GameResponseDto?)expectedGame);

            var result = await _controller.GetGameByKey(testKey);

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(expectedGame, okResult.Value);
        }

        [Test]
        public async Task GetGameByKey_WhenGameDoesNotExist_ReturnsNotFound()
        {
            var testKey = "non-existent-game";
            _mockGameService.Setup(x => x.GetGameByKeyAsync(testKey))
                .ReturnsAsync((GameResponseDto?)null);

            var result = await _controller.GetGameByKey(testKey);

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task GetGameByKey_CallsServiceWithCorrectKey()
        {
            var testKey = "test-key";
            _mockGameService.Setup(x => x.GetGameByKeyAsync(testKey))
                .ReturnsAsync(new GameResponseDto());

            await _controller.GetGameByKey(testKey);

            _mockGameService.Verify(x => x.GetGameByKeyAsync(testKey), Times.Once);
        }
    }
}
