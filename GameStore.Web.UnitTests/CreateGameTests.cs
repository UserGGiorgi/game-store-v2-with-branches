using AutoMapper;
using GameStore.Application.DTOs.Games;
using GameStore.Application.Interfaces;
using GameStore.Domain.Exceptions;
using GameStore.Infrastructure.Data;
using GameStore.Infrastructure.Services;
using GameStore.Web.Controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System.Collections.Generic;

namespace GameStore.Infrastructure.UnitTests
{
    [TestFixture]
    public class CreateGameTests
    {
        private Mock<IGameService> _mockGameService;
        private Mock<IGenreService> _mockGenreService;
        private Mock<IPlatformService> _mockPlatformService;
        private GamesController _controller;

        [SetUp]
        public void Setup()
        {
            _mockGameService = new Mock<IGameService>();
            _mockGenreService = new Mock<IGenreService>();
            _mockPlatformService = new Mock<IPlatformService>();
            _controller = new GamesController(
                _mockGameService.Object,
                _mockGenreService.Object,
                _mockPlatformService.Object);
        }

        [Test]
        public async Task CreateGame_WithValidRequest_ReturnsCreatedResult()
        {
            // Arrange
            var request = new CreateGameRequestDto();
            var expectedGame = new GameDto { Key = "test-game" };

            _mockGameService.Setup(x => x.CreateGameAsync(request))
                .ReturnsAsync(expectedGame);

            // Act
            var result = await _controller.CreateGame(request);

            // Assert
            Assert.IsInstanceOf<CreatedAtActionResult>(result);
            var createdAtResult = result as CreatedAtActionResult;
            Assert.AreEqual(nameof(_controller.GetGameByKey), createdAtResult.ActionName);
            Assert.AreEqual(expectedGame.Key, createdAtResult.RouteValues["key"]);
            Assert.AreEqual(expectedGame, createdAtResult.Value);
        }

        [Test]
        public async Task CreateGame_WithBadRequest_ReturnsBadRequest()
        {
            // Arrange
            var request = new CreateGameRequestDto();
            var errorMessage = "Invalid request";

            _mockGameService.Setup(x => x.CreateGameAsync(request))
                .ThrowsAsync(new BadRequestException(errorMessage));

            // Act
            var result = await _controller.CreateGame(request);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual(errorMessage, badRequestResult.Value);
        }

    }
}