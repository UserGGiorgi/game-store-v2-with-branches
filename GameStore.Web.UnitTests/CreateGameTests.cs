using AutoMapper;
using GameStore.Application.Dtos.Games;
using GameStore.Application.DTOs.Games;
using GameStore.Application.Interfaces;
using GameStore.Domain.Exceptions;
using GameStore.Infrastructure.Data;
using GameStore.Infrastructure.Services;
using GameStore.Web.Controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
                _mockPublisherService.Object);
        }

        [Test]
        public async Task CreateGame_WithValidRequest_ReturnsCreatedResult()
        {
            var request = new CreateGameRequestDto
            {
                Game = new GameDto { Name = "Test Game", Description = "Test Description" },
                Genres = new List<Guid> { Guid.NewGuid() },
                Platforms = new List<Guid> { Guid.NewGuid() }
            };

            var expectedGame = new GameResponseDto
            {
                Key = "test-game",
                Name = "Test Game",
                Description = "Test Description"
            };

            _mockGameService.Setup(x => x.CreateGameAsync(request))
                .ReturnsAsync(expectedGame);

            var result = await _controller.CreateGame(request);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<CreatedAtActionResult>());

            var createdAtResult = (CreatedAtActionResult)result;

            Assert.Multiple(() =>
            {
                Assert.That(createdAtResult.ActionName, Is.Not.Null.And.EqualTo(nameof(_controller.GetGameByKey)));
                Assert.That(createdAtResult.RouteValues, Is.Not.Null);
                Assert.That(createdAtResult.RouteValues!["key"], Is.EqualTo(expectedGame.Key));
                Assert.That(createdAtResult.Value, Is.EqualTo(expectedGame));
            });
        }

        [Test]
        public async Task CreateGame_WithBadRequest_ReturnsBadRequest()
        {
            var request = new CreateGameRequestDto();
            var errorMessage = "Invalid request";

            _mockGameService.Setup(x => x.CreateGameAsync(request))
                .ThrowsAsync(new BadRequestException(errorMessage));

            var result = await _controller.CreateGame(request);

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult, Is.Not.Null);
            Assert.That(badRequestResult!.Value, Is.EqualTo(errorMessage));
        }
    }
}