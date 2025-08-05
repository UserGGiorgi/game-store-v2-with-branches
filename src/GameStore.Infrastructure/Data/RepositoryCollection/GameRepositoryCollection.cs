using GameStore.Domain.Interfaces.Repositories.Games;
using GameStore.Domain.Interfaces.Repositories.Orders;

namespace GameStore.Infrastructure.Data.RepositoryCollection
{
    public class GameRepositoryCollection
    {
        public Lazy<IGameRepository> Games { get; }
        public Lazy<IGenreRepository> Genres { get; }
        public Lazy<IPlatformRepository> Platforms { get; }
        public Lazy<IOrderRepository> Orders { get; }
        public Lazy<IGameGenreRepository> GameGenres { get; }
        public Lazy<IGamePlatformRepository> GamePlatforms { get; }
        public Lazy<IOrderGameRepository> OrderGame { get; }


        public GameRepositoryCollection(
            Lazy<IGameRepository> games,
            Lazy<IGenreRepository> genres,
            Lazy<IPlatformRepository> platforms,
            Lazy<IOrderRepository> orders,
            Lazy<IGameGenreRepository> gameGenres,
            Lazy<IGamePlatformRepository> gamePlatforms,
            Lazy<IOrderGameRepository> orderGame)
        {
            Games = games;
            Genres = genres;
            Platforms = platforms;
            Orders = orders;
            GameGenres = gameGenres;
            GamePlatforms = gamePlatforms;
            OrderGame = orderGame;
        }
    }
}
