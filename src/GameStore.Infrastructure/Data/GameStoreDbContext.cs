using Microsoft.EntityFrameworkCore;
using GameStore.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GameStore.Infrastructure.Data;

public class GameStoreDbContext : DbContext
{
    public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options)
        : base(options) { }

    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Platform> Platforms => Set<Platform>();
    public DbSet<GameGenre> GameGenres => Set<GameGenre>();
    public DbSet<GamePlatform> GamePlatforms => Set<GamePlatform>();
    public DbSet<Publisher> Publishers => Set<Publisher>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderGame> OrderGames => Set<OrderGame>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<CommentBan> CommentBans => Set<CommentBan>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(g => g.Id);
            entity.Property(g => g.Key).IsRequired().HasMaxLength(50);
            entity.HasIndex(g => g.Key).IsUnique();
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(g => g.Id);
            entity.Property(g => g.Name).IsRequired().HasMaxLength(100);
            entity.HasIndex(g => g.Name).IsUnique();

            entity.HasOne(g => g.ParentGenre)
                  .WithMany(g => g.SubGenres)
                  .HasForeignKey(g => g.ParentGenreId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Type).IsRequired().HasMaxLength(50);
            entity.HasIndex(p => p.Type).IsUnique();
        });

        modelBuilder.Entity<GameGenre>(entity =>
        {
            entity.HasKey(gg => new { gg.GameId, gg.GenreId });

            entity.HasOne(gg => gg.Game)
                .WithMany(g => g.Genres)
                .HasForeignKey(gg => gg.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(gg => gg.Genre)
                .WithMany(g => g.Games)
                .HasForeignKey(gg => gg.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<GamePlatform>(entity =>
        {
            entity.HasKey(gp => new { gp.GameId, gp.PlatformId });

            entity.HasOne(gp => gp.Game)
                  .WithMany(g => g.Platforms)
                  .HasForeignKey(gp => gp.GameId);

            entity.HasOne(gp => gp.Platform)
                  .WithMany(p => p.Games)
                  .HasForeignKey(gp => gp.PlatformId);
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasIndex(p => p.CompanyName).IsUnique();
        });

        modelBuilder.Entity<Game>()
            .HasOne(g => g.Publisher)
            .WithMany(p => p.Games)
            .HasForeignKey(g => g.PublisherId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrderGame>()
        .HasKey(og => new { og.OrderId, og.ProductId });

        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderGames)
            .WithOne(og => og.Order)
            .HasForeignKey(og => og.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderGame>()
            .HasOne(og => og.Game)
            .WithMany()
            .HasForeignKey(og => og.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Comment>()
        .HasMany(c => c.Replies)
        .WithOne(c => c.ParentComment)
        .HasForeignKey(c => c.ParentCommentId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Game)
            .WithMany(g => g.Comments)
            .HasForeignKey(c => c.GameId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CommentBan>()
            .HasOne(cb => cb.Game)
            .WithMany(g => g.CommentBans)
            .HasForeignKey(cb => cb.GameId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}