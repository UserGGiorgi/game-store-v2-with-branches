using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOrderGameAlternateKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_OrderGames_OrderId_ProductId",
                table: "OrderGames");

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-111111111111"),
                column: "DisplayName",
                value: "Administrator Administrator");

            migrationBuilder.CreateIndex(
                name: "IX_OrderGames_OrderId",
                table: "OrderGames",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderGames_OrderId",
                table: "OrderGames");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_OrderGames_OrderId_ProductId",
                table: "OrderGames",
                columns: ["OrderId", "ProductId"]);

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-111111111111"),
                column: "DisplayName",
                value: "Administrator");
        }
    }
}
