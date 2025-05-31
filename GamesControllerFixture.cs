using System;

public class GamesControllerFixture : IDisposable
{
    public Mock<IGameService> MockGameService { get; }
    public Mock<IValidator<CreateGameRequestDto>> MockCreateValidator { get; }
    public Mock<IValidator<UpdateGameRequestDto>> MockUpdateValidator { get; }

    public GamesControllerFixture()
    {
        MockGameService = new Mock<IGameService>();
        MockCreateValidator = new Mock<IValidator<CreateGameRequestDto>>();
        MockUpdateValidator = new Mock<IValidator<UpdateGameRequestDto>>();
    }

    public void Dispose()
    {
        // Clean up if needed
    }

    public GamesController CreateController()
    {
        return new GamesController(
            MockGameService.Object,
            MockCreateValidator.Object,
            MockUpdateValidator.Object);
    }
}