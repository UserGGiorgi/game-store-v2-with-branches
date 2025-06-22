using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderGame_Games_ProductId",
                table: "OrderGame");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderGame_Order_OrderId",
                table: "OrderGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderGame",
                table: "OrderGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "OrderGame",
                newName: "OrderGames");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_OrderGame_ProductId",
                table: "OrderGames",
                newName: "IX_OrderGames_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderGames",
                table: "OrderGames",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderGames_Games_ProductId",
                table: "OrderGames",
                column: "ProductId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderGames_Orders_OrderId",
                table: "OrderGames",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderGames_Games_ProductId",
                table: "OrderGames");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderGames_Orders_OrderId",
                table: "OrderGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderGames",
                table: "OrderGames");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "OrderGames",
                newName: "OrderGame");

            migrationBuilder.RenameIndex(
                name: "IX_OrderGames_ProductId",
                table: "OrderGame",
                newName: "IX_OrderGame_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderGame",
                table: "OrderGame",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderGame_Games_ProductId",
                table: "OrderGame",
                column: "ProductId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderGame_Order_OrderId",
                table: "OrderGame",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
