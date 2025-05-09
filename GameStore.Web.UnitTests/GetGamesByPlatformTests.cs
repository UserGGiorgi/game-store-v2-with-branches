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
        public async Task GetGamesByPlatform_WithEmptyPlatformId_ReturnsBadRequest()
        {
            var emptyPlatformId = Guid.Empty;
            const string expectedErrorMessage = "Platform ID cannot be empty";

            var result = await _controller.GetGamesByPlatform(emptyPlatformId);

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result as BadRequestObjectResult;

            Assert.Multiple(() =>
            {
                Assert.That(badRequestResult, Is.Not.Null);
                Assert.That(badRequestResult!.Value, Is.EqualTo(expectedErrorMessage));
            });
        }

    }
}
