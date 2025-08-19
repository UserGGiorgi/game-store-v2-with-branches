using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorizationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserEmail",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserEmail",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserEmail, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_ApplicationUser_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "ApplicationUser",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: ["Email", "DisplayName"],
                values: ["admin@game-store.com", "Administrator"]);

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: ["Id", "Description", "Name"],
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000101"), "Auto-generated description for ManageUsers", "ManageUsers" },
                    { new Guid("00000000-0000-0000-0000-000000000102"), "Auto-generated description for ViewUsers", "ViewUsers" },
                    { new Guid("00000000-0000-0000-0000-000000000103"), "Auto-generated description for ManageRoles", "ManageRoles" },
                    { new Guid("00000000-0000-0000-0000-000000000104"), "Auto-generated description for AssignRoles", "AssignRoles" },
                    { new Guid("00000000-0000-0000-0000-000000000105"), "Auto-generated description for ManageGames", "ManageGames" },
                    { new Guid("00000000-0000-0000-0000-000000000106"), "Auto-generated description for ViewDeletedGames", "ViewDeletedGames" },
                    { new Guid("00000000-0000-0000-0000-000000000107"), "Auto-generated description for EditDeletedGames", "EditDeletedGames" },
                    { new Guid("00000000-0000-0000-0000-000000000108"), "Auto-generated description for ViewGames", "ViewGames" },
                    { new Guid("00000000-0000-0000-0000-000000000109"), "Auto-generated description for BuyGames", "BuyGames" },
                    { new Guid("00000000-0000-0000-0000-000000000110"), "Auto-generated description for ManageGenres", "ManageGenres" },
                    { new Guid("00000000-0000-0000-0000-000000000111"), "Auto-generated description for ManagePlatforms", "ManagePlatforms" },
                    { new Guid("00000000-0000-0000-0000-000000000112"), "Auto-generated description for ManagePublishers", "ManagePublishers" },
                    { new Guid("00000000-0000-0000-0000-000000000113"), "Auto-generated description for ManageOrders", "ManageOrders" },
                    { new Guid("00000000-0000-0000-0000-000000000114"), "Auto-generated description for ViewOrderHistory", "ViewOrderHistory" },
                    { new Guid("00000000-0000-0000-0000-000000000115"), "Auto-generated description for UpdateOrderStatus", "UpdateOrderStatus" },
                    { new Guid("00000000-0000-0000-0000-000000000116"), "Auto-generated description for EditOrderDetails", "EditOrderDetails" },
                    { new Guid("00000000-0000-0000-0000-000000000117"), "Auto-generated description for ManageComments", "ManageComments" },
                    { new Guid("00000000-0000-0000-0000-000000000118"), "Auto-generated description for PostComments", "PostComments" },
                    { new Guid("00000000-0000-0000-0000-000000000119"), "Auto-generated description for BanCommenters", "BanCommenters" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: ["Id", "IsDefault", "Name"],
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), true, "Admin" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), true, "Manager" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), true, "Moderator" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), true, "User" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), true, "Guest" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: ["PermissionId", "RoleId"],
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000101"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000102"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000103"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000104"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000105"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000106"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000107"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000108"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000109"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000110"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000111"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000112"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000113"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000114"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000115"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000116"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000117"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000118"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000119"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000102"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000105"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000106"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000110"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000111"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000112"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000113"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000114"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000115"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000116"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000108"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000109"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000117"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000118"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000119"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000108"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000109"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000118"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000108"), new Guid("00000000-0000-0000-0000-000000000005") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: ["RoleId", "UserEmail"],
                values: [new Guid("00000000-0000-0000-0000-000000000001"), "admin@game-store.com"]);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserEmail",
                table: "Orders",
                column: "ApplicationUserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ApplicationUserEmail",
                table: "Comments",
                column: "ApplicationUserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ApplicationUser_ApplicationUserEmail",
                table: "Comments",
                column: "ApplicationUserEmail",
                principalTable: "ApplicationUser",
                principalColumn: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ApplicationUser_ApplicationUserEmail",
                table: "Orders",
                column: "ApplicationUserEmail",
                principalTable: "ApplicationUser",
                principalColumn: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ApplicationUser_ApplicationUserEmail",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ApplicationUser_ApplicationUserEmail",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ApplicationUserEmail",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ApplicationUserEmail",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserEmail",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApplicationUserEmail",
                table: "Comments");
        }
    }
}
