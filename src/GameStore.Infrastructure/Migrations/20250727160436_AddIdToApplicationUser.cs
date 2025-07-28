using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIdToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ApplicationUser_ApplicationUserEmail",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ApplicationUser_ApplicationUserEmail",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_ApplicationUser_UserEmail",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ApplicationUserEmail",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ApplicationUserEmail",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserEmail" },
                keyColumnTypes: new[] { "uniqueidentifier", "nvarchar(450)" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "admin@game-store.com" });

            migrationBuilder.DeleteData(
                table: "ApplicationUser",
                keyColumn: "Email",
                keyValue: "admin@game-store.com");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "ApplicationUserEmail",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApplicationUserEmail",
                table: "Comments");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ApplicationUser",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ApplicationUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser",
                column: "Id");

            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: new[] { "Id", "DisplayName", "Email" },
                values: new object[] { new Guid("00000000-0000-0000-0000-111111111111"), "Administrator", "admin@game-store.com" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-111111111111") });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_Email",
                table: "ApplicationUser",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ApplicationUser_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ApplicationUser_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_ApplicationUser_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ApplicationUser_ApplicationUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ApplicationUser_ApplicationUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_ApplicationUser_UserId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ApplicationUserId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUser_Email",
                table: "ApplicationUser");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyColumnTypes: new[] { "uniqueidentifier", "uniqueidentifier" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-111111111111") });

            migrationBuilder.DeleteData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("00000000-0000-0000-0000-111111111111"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ApplicationUser");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "UserRoles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ApplicationUser",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserEmail", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser",
                column: "Email");

            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: new[] { "Email", "DisplayName" },
                values: new object[] { "admin@game-store.com", "Administrator" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserEmail" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "admin@game-store.com" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserEmail",
                table: "Orders",
                column: "ApplicationUserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ApplicationUserEmail",
                table: "Comments",
                column: "ApplicationUserEmail");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_ApplicationUser_UserEmail",
                table: "UserRoles",
                column: "UserEmail",
                principalTable: "ApplicationUser",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
