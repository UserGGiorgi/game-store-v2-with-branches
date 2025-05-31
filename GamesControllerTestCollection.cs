using System;

[CollectionDefinition("GamesControllerTests")]
public class GamesControllerTestCollection : ICollectionFixture<GamesControllerFixture> { }

[Collection("GamesControllerTests")]
public class CreateGameTests : IClassFixture<GamesControllerFixture>
{
    private readonly GamesControllerFixture _fixture;

    public CreateGameTests(GamesControllerFixture fixture)
    {
        _fixture = fixture;
        _fixture.MockCreateValidator.Invocations.Clear();
        _fixture.MockGameService.Invocations.Clear();
    }

    [Fact]
    public async Task CreateGame_Returns201Created_WhenRequestIsValid()
    {
        // Arrange
        var request = GamesControllerTestData.ValidCreateRequest;
        var expectedGame = GamesControllerTestData.ValidGameDto;

        _fixture.MockCreateValidator
            .Setup(v => v.ValidateAsync(request, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());

        _fixture.MockGameService
            .Setup(s => s.CreateGameAsync(request))
            .ReturnsAsync(expectedGame);

        var controller = _fixture.CreateController();

        // Act
        var result = await controller.CreateGame(request, CancellationToken.None);

        // Assert
        var createdAtResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(nameof(GamesController.GetByKey), createdAtResult.ActionName);
        Assert.Equal(expectedGame.Key, (createdAtResult.RouteValues?["key"] as string));
        Assert.Equal(expectedGame, createdAtResult.Value);

        _fixture.MockCreateValidator.Verify(
            v => v.ValidateAsync(request, It.IsAny<CancellationToken>()),
            Times.Once);

        _fixture.MockGameService.Verify(
            s => s.CreateGameAsync(request),
            Times.Once);
    }

    [Fact]
    public async Task CreateGame_Returns400BadRequest_WhenValidationFails()
    {
        // Arrange
        var request = GamesControllerTestData.ValidCreateRequest;
        var validationErrors = new ValidationResult(new[]
        {
            new ValidationFailure("Name", "Name is required")
        });

        _fixture.MockCreateValidator
            .Setup(v => v.ValidateAsync(request, It.IsAny<CancellationToken>()))
            .ReturnsAsync(validationErrors);

        var controller = _fixture.CreateController();

        // Act
        var result = await controller.CreateGame(request, CancellationToken.None);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        var errors = Assert.IsType<Dictionary<string, string[]>>(badRequestResult.Value);
        Assert.Contains("Name", errors.Keys);

        _fixture.MockGameService.Verify(
            s => s.CreateGameAsync(It.IsAny<CreateGameRequestDto>()),
            Times.Never);
    }

    [Fact]
    public async Task CreateGame_Returns400BadRequest_WhenServiceThrowsBadRequestException()
    {
        // Arrange
        var request = GamesControllerTestData.ValidCreateRequest;
        var errorMessage = "Game key already exists";

        _fixture.MockCreateValidator
            .Setup(v => v.ValidateAsync(request, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());

        _fixture.MockGameService
            .Setup(s => s.CreateGameAsync(request))
            .ThrowsAsync(new BadRequestException(errorMessage));

        var controller = _fixture.CreateController();

        // Act
        var result = await controller.CreateGame(request, CancellationToken.None);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(errorMessage, badRequestResult.Value);
    }

    [Fact]
    public async Task CreateGame_ValidatesGameDtoAndCollections()
    {
        // Arrange
        var invalidRequest = new CreateGameRequestDto
        {
            Game = new GameDto { Key = "invalid key!", Name = "" },
            Genres = new List<Guid>(),
            Platforms = new List<Guid>()
        };

        var controller = _fixture.CreateController();

        // Act
        var result = await controller.CreateGame(invalidRequest, CancellationToken.None);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}