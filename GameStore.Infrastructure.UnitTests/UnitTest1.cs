using AutoMapper;
using GameStore.Infrastructure.Data;
using GameStore.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System.Collections.Generic;

namespace GameStore.Infrastructure.UnitTests
{
    [TestFixture]
    public class GameServiceTests
    {
        private Mock<GameStoreDbContext> _mockContext;
        private Mock<IMapper> _mockMapper;
        private Mock<IMemoryCache> _mockCache;
        private GameService _gameService;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<GameStoreDbContext>();
            _mockMapper = new Mock<IMapper>();
            _mockCache = new Mock<IMemoryCache>();
            _gameService = new GameService(_mockContext.Object, _mockMapper.Object, _mockCache.Object);
        }

        private static DbSet<T> MockDbSet<T>(IEnumerable<T> data) where T : class
        {
            var queryable = data.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            return mockSet.Object;
        }

    }
}