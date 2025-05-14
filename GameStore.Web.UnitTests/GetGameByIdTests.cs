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
        public async Task GetGameById_WithValidId_ReturnsOkWithGame()
        {
            var testId = Guid.NewGuid();
            var expectedGame = new GameResponseDto { Id = testId, Key = "test-game" };

            _mockGameService.Setup(x => x.GetGameByIdAsync(testId))
                .ReturnsAsync(expectedGame);

            var result = await _controller.GetGameById(testId);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = (OkObjectResult)result;
            Assert.That(okResult.Value, Is.EqualTo(expectedGame));
        }

        [Test]
        public async Task GetGameById_WithNonExistentId_ReturnsNotFound()
        {
            var testId = Guid.NewGuid();

            _mockGameService.Setup(x => x.GetGameByIdAsync(testId))
                .ReturnsAsync((GameResponseDto?)null);

            var result = await _controller.GetGameById(testId);

            Assert.That(result, Is.InstanceOf<NotFoundResult>());
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

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.That(badRequestResult.Value, Is.EqualTo("Game ID cannot be empty"));
        }
    }
}
