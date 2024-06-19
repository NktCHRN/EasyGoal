using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGoal.Backend.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskStartTimeEndTimeIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StartTime_EndTime",
                table: "Tasks",
                columns: new[] { "StartTime", "EndTime" },
                filter: "\"IsDeleted\" = false");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tasks_StartTime_EndTime",
                table: "Tasks");
        }
    }
}
