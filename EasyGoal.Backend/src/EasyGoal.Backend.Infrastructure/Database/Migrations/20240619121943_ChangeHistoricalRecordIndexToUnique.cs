using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGoal.Backend.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class ChangeHistoricalRecordIndexToUnique : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_HistoricalRecords_SubGoalId_Date",
            table: "HistoricalRecords");

        migrationBuilder.CreateIndex(
            name: "IX_HistoricalRecords_SubGoalId_Date",
            table: "HistoricalRecords",
            columns: new[] { "SubGoalId", "Date" },
            unique: true,
            descending: new[] { false, true },
            filter: "\"IsDeleted\" = false");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_HistoricalRecords_SubGoalId_Date",
            table: "HistoricalRecords");

        migrationBuilder.CreateIndex(
            name: "IX_HistoricalRecords_SubGoalId_Date",
            table: "HistoricalRecords",
            columns: new[] { "SubGoalId", "Date" },
            descending: new[] { false, true });
    }
}
