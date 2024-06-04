using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGoal.Backend.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class AddIndicesForRefreshTokens : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_RefreshTokens_UserId",
            table: "RefreshTokens");

        migrationBuilder.CreateIndex(
            name: "IX_RefreshTokens_UserId_Token",
            table: "RefreshTokens",
            columns: new[] { "UserId", "Token" },
            filter: "\"IsDeleted\" = false");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_RefreshTokens_UserId_Token",
            table: "RefreshTokens");

        migrationBuilder.CreateIndex(
            name: "IX_RefreshTokens_UserId",
            table: "RefreshTokens",
            column: "UserId");
    }
}
