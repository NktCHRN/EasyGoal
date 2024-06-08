using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGoal.Backend.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class ChangeHistoryRecordsTableName : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "HistoryRecords");

        migrationBuilder.CreateTable(
            name: "HistoricalRecords",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Date = table.Column<DateOnly>(type: "date", nullable: false),
                CurrentDoneItems = table.Column<int>(type: "integer", nullable: false),
                CurrentTotalItems = table.Column<int>(type: "integer", nullable: false),
                SubGoalId = table.Column<Guid>(type: "uuid", nullable: false),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_HistoricalRecords", x => x.Id);
                table.ForeignKey(
                    name: "FK_HistoricalRecords_SubGoals_SubGoalId",
                    column: x => x.SubGoalId,
                    principalTable: "SubGoals",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_HistoricalRecords_SubGoalId",
            table: "HistoricalRecords",
            column: "SubGoalId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "HistoricalRecords");

        migrationBuilder.CreateTable(
            name: "HistoryRecords",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                SubGoalId = table.Column<Guid>(type: "uuid", nullable: false),
                CurrentDoneItems = table.Column<int>(type: "integer", nullable: false),
                CurrentTotalItems = table.Column<int>(type: "integer", nullable: false),
                Date = table.Column<DateOnly>(type: "date", nullable: false),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_HistoryRecords", x => x.Id);
                table.ForeignKey(
                    name: "FK_HistoryRecords_SubGoals_SubGoalId",
                    column: x => x.SubGoalId,
                    principalTable: "SubGoals",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_HistoryRecords_SubGoalId",
            table: "HistoryRecords",
            column: "SubGoalId");
    }
}
