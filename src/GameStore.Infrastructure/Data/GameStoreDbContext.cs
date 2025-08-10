using Microsoft.EntityFrameworkCore;
using GameStore.Domain.Entities.User;
using GameStore.Domain.Entities.Comments;
using GameStore.Domain.Entities.Orders;
using GameStore.Domain.Entities.Games;

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
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<ApplicationUser> ApplicationUser => Set<ApplicationUser>();

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

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(rp => new { rp.RoleId, rp.PermissionId });

            entity.HasOne(rp => rp.Role)
                  .WithMany(r => r.RolePermissions)
                  .HasForeignKey(rp => rp.RoleId);

            entity.HasOne(rp => rp.Permission)
                  .WithMany(p => p.RolePermissions)
                  .HasForeignKey(rp => rp.PermissionId);
        });

        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasIndex(u => u.Email)
                .IsUnique();
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(ur => new { ur.UserId, ur.RoleId });

            entity.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        SeedDefaultRolesAndPermissions(modelBuilder);

    }
    private static void SeedDefaultRolesAndPermissions(ModelBuilder modelBuilder)
    {
        var adminUserId = Guid.Parse("00000000-0000-0000-0000-111111111111");

        modelBuilder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = adminUserId,
                Email = "admin@game-store.com",
                DisplayName = "Administrator"
            });

        var permissionMap = new Dictionary<string, Guid>
    {
        { "ManageUsers", Guid.Parse("00000000-0000-0000-0000-000000000101") },
        { "ViewUsers", Guid.Parse("00000000-0000-0000-0000-000000000102") },
        { "ManageRoles", Guid.Parse("00000000-0000-0000-0000-000000000103") },
        { "AssignRoles", Guid.Parse("00000000-0000-0000-0000-000000000104") },
        { "ManageGames", Guid.Parse("00000000-0000-0000-0000-000000000105") },
        { "ViewDeletedGames", Guid.Parse("00000000-0000-0000-0000-000000000106") },
        { "EditDeletedGames", Guid.Parse("00000000-0000-0000-0000-000000000107") },
        { "ViewGames", Guid.Parse("00000000-0000-0000-0000-000000000108") },
        { "BuyGames", Guid.Parse("00000000-0000-0000-0000-000000000109") },
        { "ManageGenres", Guid.Parse("00000000-0000-0000-0000-000000000110") },
        { "ManagePlatforms", Guid.Parse("00000000-0000-0000-0000-000000000111") },
        { "ManagePublishers", Guid.Parse("00000000-0000-0000-0000-000000000112") },
        { "ManageOrders", Guid.Parse("00000000-0000-0000-0000-000000000113") },
        { "ViewOrderHistory", Guid.Parse("00000000-0000-0000-0000-000000000114") },
        { "UpdateOrderStatus", Guid.Parse("00000000-0000-0000-0000-000000000115") },
        { "EditOrderDetails", Guid.Parse("00000000-0000-0000-0000-000000000116") },
        { "ManageComments", Guid.Parse("00000000-0000-0000-0000-000000000117") },
        { "PostComments", Guid.Parse("00000000-0000-0000-0000-000000000118") },
        { "BanCommenters", Guid.Parse("00000000-0000-0000-0000-000000000119") }
    };

        var permissions = permissionMap.Select(kvp => new Permission
        {
            Id = kvp.Value,
            Name = kvp.Key,
            Description = $"Auto-generated description for {kvp.Key}"
        }).ToList();

        var roles = new List<Role>
    {
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Admin", IsDefault = true },
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Manager", IsDefault = true },
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Moderator", IsDefault = true },
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "User", IsDefault = true },
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Guest", IsDefault = true }
    };

        var rolePermissions = new List<RolePermission>();

        void AddPermissionsToRole(Guid roleId, params string[] permissionNames)
        {
            foreach (var name in permissionNames)
            {
                rolePermissions.Add(new RolePermission
                {
                    RoleId = roleId,
                    PermissionId = permissionMap[name]
                });
            }
        }

        AddPermissionsToRole(roles[0].Id, permissionMap.Keys.ToArray());

        AddPermissionsToRole(roles[1].Id,
            "ManageGames", "ViewDeletedGames", "ManageGenres", "ManagePlatforms",
            "ManagePublishers", "ManageOrders", "ViewOrderHistory", "UpdateOrderStatus",
            "EditOrderDetails", "ViewUsers"
        );

        AddPermissionsToRole(roles[2].Id,
            "ManageComments", "BanCommenters", "PostComments", "ViewGames", "BuyGames"
        );

        AddPermissionsToRole(roles[3].Id, "ViewGames", "BuyGames", "PostComments");

        AddPermissionsToRole(roles[4].Id, "ViewGames");

        modelBuilder.Entity<Permission>().HasData(permissions);
        modelBuilder.Entity<Role>().HasData(roles);

        modelBuilder.Entity<RolePermission>().HasData(
        rolePermissions.Select(rp => new { rp.RoleId, rp.PermissionId })
        );

        var adminRoleId = roles[0].Id;

        modelBuilder.Entity<UserRole>().HasData(
            new UserRole
            {
                UserId = adminUserId,
                RoleId = adminRoleId
            }
        );
    }

}