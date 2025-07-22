using GameStore.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Data.RepositoryCollection
{
    public class GameRepositoryCollection
    {
        public Lazy<IGameRepository> Games { get; }
        public Lazy<IGenreRepository> Genres { get; }
        public Lazy<IPlatformRepository> Platforms { get; }
        public Lazy<IPublisherRepository> Publishers { get; }
        public Lazy<IOrderRepository> Orders { get; }
        public Lazy<IGameGenreRepository> GameGenres { get; }
        public Lazy<IGamePlatformRepository> GamePlatforms { get; }


        public GameRepositoryCollection(
            Lazy<IGameRepository> games,
            Lazy<IGenreRepository> genres,
            Lazy<IPlatformRepository> platforms,
            Lazy<IPublisherRepository> publishers,
            Lazy<IOrderRepository> orders,
            Lazy<IGameGenreRepository> gameGenres,
            Lazy<IGamePlatformRepository> gamePlatforms)
        {
            Games = games;
            Genres = genres;
            Platforms = platforms;
            Publishers = publishers;
            Orders = orders;
            GameGenres = gameGenres;
            GamePlatforms = gamePlatforms;
        }
    }
}
