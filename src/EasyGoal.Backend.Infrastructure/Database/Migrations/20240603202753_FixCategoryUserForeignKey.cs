using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGoal.Backend.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class FixCategoryUserForeignKey : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Categories_AspNetUsers_IdentityApplicationUserId",
            table: "Categories");

        migrationBuilder.DropIndex(
            name: "IX_Categories_IdentityApplicationUserId",
            table: "Categories");

        migrationBuilder.DropColumn(
            name: "IdentityApplicationUserId",
            table: "Categories");

        migrationBuilder.CreateIndex(
            name: "IX_Categories_UserId",
            table: "Categories",
            column: "UserId");

        migrationBuilder.AddForeignKey(
            name: "FK_Categories_AspNetUsers_UserId",
            table: "Categories",
            column: "UserId",
            principalTable: "AspNetUsers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Categories_AspNetUsers_UserId",
            table: "Categories");

        migrationBuilder.DropIndex(
            name: "IX_Categories_UserId",
            table: "Categories");

        migrationBuilder.AddColumn<Guid>(
            name: "IdentityApplicationUserId",
            table: "Categories",
            type: "uuid",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_Categories_IdentityApplicationUserId",
            table: "Categories",
            column: "IdentityApplicationUserId");

        migrationBuilder.AddForeignKey(
            name: "FK_Categories_AspNetUsers_IdentityApplicationUserId",
            table: "Categories",
            column: "IdentityApplicationUserId",
            principalTable: "AspNetUsers",
            principalColumn: "Id");
    }
}
