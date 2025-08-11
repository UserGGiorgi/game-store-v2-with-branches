using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderGamePrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderGames",
                table: "OrderGames");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "OrderGames",
                nullable: true); // Allow NULL temporarily

            migrationBuilder.Sql(@"
            UPDATE [OrderGames] 
            SET [Id] = NEWID() 
            WHERE [Id] IS NULL
             ");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderGames",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderGames",
                table: "OrderGames",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_OrderGames_OrderId_ProductId",
                table: "OrderGames",
                columns: new[] { "OrderId", "ProductId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_OrderGames_OrderId_ProductId",
                table: "OrderGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderGames",
                table: "OrderGames");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderGames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderGames",
                table: "OrderGames",
                columns: new[] { "OrderId", "ProductId" });
        }
    }
}
