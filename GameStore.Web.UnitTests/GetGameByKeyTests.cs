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
        private Mock<IGenreService> _mockGenreService;
        private Mock<IPlatformService> _mockPlatformService;
        private Mock<IPublisherService> _mockPublisherService;
        private GamesController _controller;

        [SetUp]
        public void Setup()
        {
            _mockGameService = new Mock<IGameService>();
            _mockGenreService = new Mock<IGenreService>();
            _mockPlatformService = new Mock<IPlatformService>();
            _mockPublisherService = new Mock<IPublisherService>();

            _controller = new GamesController(
                _mockGameService.Object,
                _mockGenreService.Object,
                _mockPlatformService.Object,
                _mockPublisherService.Object
            );
        }

        [Test]
        public async Task GetGameByKey_WhenGameExists_ReturnsOkWithGame()
        {
            var testKey = "test-game";
            var expectedGame = new GameResponseDto { Key = testKey };

            _mockGameService.Setup(x => x.GetGameByKeyAsync(testKey))
                .ReturnsAsync(expectedGame);

            var result = await _controller.GetGameByKey(testKey);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;

            Assert.That(okResult?.Value, Is.EqualTo(expectedGame));
        }

        [Test]
        public async Task GetGameByKey_WhenGameDoesNotExist_ReturnsNotFound()
        {
            var testKey = "non-existent-game";
            _mockGameService.Setup(x => x.GetGameByKeyAsync(testKey))
                .ReturnsAsync((GameResponseDto?)null);

            var result = await _controller.GetGameByKey(testKey);

            Assert.That(result, Is.InstanceOf<NotFoundResult>());
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
