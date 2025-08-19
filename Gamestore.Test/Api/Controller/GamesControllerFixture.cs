using FluentValidation;
using GameStore.Api.Controllers.Games;
using GameStore.Application.Dtos.Games.CreateGame;
using GameStore.Application.Dtos.Games.CreateGames;
using GameStore.Application.Dtos.Games.GetGame;
using GameStore.Application.Dtos.Games.GetGames;
using GameStore.Application.Dtos.Games.UpdateGames;
using GameStore.Application.Interfaces.Games;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamestore.Test.Api.Controller
{
    public class GamesControllerFixture
    {
        public Mock<IGameService> MockGameService { get; }
        public Mock<IValidator<CreateGameRequestDto>> MockCreateValidator { get; }
        public Mock<IValidator<UpdateGameRequestDto>> MockUpdateValidator { get; }
        public Mock<ILogger<GamesController>> MockLogger { get; }

        public GamesController Controller { get; }

        public static CreateGameRequestDto ValidCreateRequest => new()
        {
            Game = new CreateGameDto
            {
                Name = "Valid Game",
                Key = "valid-game-key",
                Description = "Valid description"
            },
            Genres = new List<Guid> { Guid.NewGuid() },
            Platforms = new List<Guid> { Guid.NewGuid() }
        };

        public GamesControllerFixture()
        {
            MockGameService = new Mock<IGameService>();
            MockCreateValidator = new Mock<IValidator<CreateGameRequestDto>>();
            MockUpdateValidator = new Mock<IValidator<UpdateGameRequestDto>>();
            MockLogger = new Mock<ILogger<GamesController>>();

            Controller = new GamesController(
                MockGameService.Object,
                MockCreateValidator.Object,
                MockUpdateValidator.Object,
                MockLogger.Object
            );
        }

        public void SetupGameServiceForGetByPlatform(
    Guid platformId,
    IEnumerable<SimpleGameResponseDto> returnValue = null!,
    Exception exception = null!)
        {
            if (exception != null)
            {
                MockGameService
                    .Setup(s => s.GetGamesByPlatformAsync(platformId))
                    .ThrowsAsync(exception);
            }
            else
            {
                MockGameService
                    .Setup(s => s.GetGamesByPlatformAsync(platformId))
                    .ReturnsAsync(returnValue ?? []);
            }
        }

        public void SetupGameServiceForGetByGenre(
            Guid genreId,
            IEnumerable<SimpleGameResponseDto> returnValue = null!,
            Exception exception = null!)
        {
            if (exception != null)
            {
                MockGameService
                    .Setup(s => s.GetGamesByGenreAsync(genreId))
                    .ThrowsAsync(exception);
            }
            else
            {
                MockGameService
                    .Setup(s => s.GetGamesByGenreAsync(genreId))
                    .ReturnsAsync(returnValue ?? []);
            }
        }
        public void SetupGameServiceForDelete(
    string key,
    Exception exception = null!)
        {
            if (exception != null)
            {
                MockGameService
                    .Setup(s => s.DeleteGameAsync(key))
                    .ThrowsAsync(exception);
            }
            else
            {
                MockGameService
                    .Setup(s => s.DeleteGameAsync(key))
                    .Returns(Task.CompletedTask);
            }
        }
    }
}
