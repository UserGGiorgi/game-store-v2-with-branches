using System;

public static class GamesControllerTestData
{
    public static CreateGameRequestDto ValidCreateRequest => new()
    {
        Game = new GameDto
        {
            Key = "valid-game",
            Name = "Valid Game",
            Description = "A valid game description"
        },
        Genres = new List<Guid> { Guid.NewGuid() },
        Platforms = new List<Guid> { Guid.NewGuid() }
    };

    public static GameDto ValidGameDto => new()
    {
        Key = "valid-game",
        Name = "Valid Game",
        Description = "A valid game description"
    };
}
