using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGoal.Backend.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class RemoveAuditableFromRefreshTokens : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "CreatedAt",
            table: "RefreshTokens");

        migrationBuilder.DropColumn(
            name: "CreatedBy",
            table: "RefreshTokens");

        migrationBuilder.DropColumn(
            name: "ModifiedAt",
            table: "RefreshTokens");

        migrationBuilder.DropColumn(
            name: "ModifiedBy",
            table: "RefreshTokens");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<DateTimeOffset>(
            name: "CreatedAt",
            table: "RefreshTokens",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

        migrationBuilder.AddColumn<string>(
            name: "CreatedBy",
            table: "RefreshTokens",
            type: "character varying(256)",
            maxLength: 256,
            nullable: true);

        migrationBuilder.AddColumn<DateTimeOffset>(
            name: "ModifiedAt",
            table: "RefreshTokens",
            type: "timestamp with time zone",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "ModifiedBy",
            table: "RefreshTokens",
            type: "character varying(256)",
            maxLength: 256,
            nullable: true);
    }
}
