using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGoal.Backend.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class AddHistoricalRecordIndex : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_HistoricalRecords_SubGoalId",
            table: "HistoricalRecords");

        migrationBuilder.CreateIndex(
            name: "IX_HistoricalRecords_SubGoalId_Date",
            table: "HistoricalRecords",
            columns: new[] { "SubGoalId", "Date" },
            descending: new[] { false, true });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_HistoricalRecords_SubGoalId_Date",
            table: "HistoricalRecords");

        migrationBuilder.CreateIndex(
            name: "IX_HistoricalRecords_SubGoalId",
            table: "HistoricalRecords",
            column: "SubGoalId");
    }
}
