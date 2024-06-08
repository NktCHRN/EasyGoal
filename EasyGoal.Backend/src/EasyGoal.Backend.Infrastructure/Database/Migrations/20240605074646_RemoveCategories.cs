using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGoal.Backend.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class RemoveCategories : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Categories");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Categories",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                ColorHex = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: false),
                CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                CreatedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                ModifiedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                UserId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Categories", x => x.Id);
                table.ForeignKey(
                    name: "FK_Categories_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Categories_UserId",
            table: "Categories",
            column: "UserId");
    }
}
