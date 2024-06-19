using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGoal.Backend.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangeHistoricalRecordDateToDateTimeOffset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HistoricalRecords_SubGoalId_Date",
                table: "HistoricalRecords");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "HistoricalRecords");

            migrationBuilder.DropColumn(
                name: "xmin",
                table: "HistoricalRecords");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateTime",
                table: "HistoricalRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalRecords_SubGoalId_DateTime",
                table: "HistoricalRecords",
                columns: new[] { "SubGoalId", "DateTime" },
                descending: new[] { false, true },
                filter: "\"IsDeleted\" = false");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HistoricalRecords_SubGoalId_DateTime",
                table: "HistoricalRecords");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "HistoricalRecords");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "HistoricalRecords",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<uint>(
                name: "xmin",
                table: "HistoricalRecords",
                type: "xid",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalRecords_SubGoalId_Date",
                table: "HistoricalRecords",
                columns: new[] { "SubGoalId", "Date" },
                unique: true,
                descending: new[] { false, true },
                filter: "\"IsDeleted\" = false");
        }
    }
}
