using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GameStore.Infrastructure.Data;

public class GameStoreDbContextFactory : IDesignTimeDbContextFactory<GameStoreDbContext>
{
    public GameStoreDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../GameStore.Api"))
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<GameStoreDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.UseSqlServer(connectionString);

        return new GameStoreDbContext(builder.Options);
    }
}