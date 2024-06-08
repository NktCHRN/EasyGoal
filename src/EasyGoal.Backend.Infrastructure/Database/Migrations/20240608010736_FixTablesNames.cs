using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGoal.Backend.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class FixTablesNames : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_HistoryRecord_SubGoals_SubGoalId",
            table: "HistoryRecord");

        migrationBuilder.DropForeignKey(
            name: "FK_SubTask_Tasks_TaskId",
            table: "SubTask");

        migrationBuilder.DropPrimaryKey(
            name: "PK_SubTask",
            table: "SubTask");

        migrationBuilder.DropPrimaryKey(
            name: "PK_HistoryRecord",
            table: "HistoryRecord");

        migrationBuilder.RenameTable(
            name: "SubTask",
            newName: "SubTasks");

        migrationBuilder.RenameTable(
            name: "HistoryRecord",
            newName: "HistoryRecords");

        migrationBuilder.RenameIndex(
            name: "IX_SubTask_TaskId",
            table: "SubTasks",
            newName: "IX_SubTasks_TaskId");

        migrationBuilder.RenameIndex(
            name: "IX_HistoryRecord_SubGoalId",
            table: "HistoryRecords",
            newName: "IX_HistoryRecords_SubGoalId");

        migrationBuilder.AddPrimaryKey(
            name: "PK_SubTasks",
            table: "SubTasks",
            column: "Id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_HistoryRecords",
            table: "HistoryRecords",
            column: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_HistoryRecords_SubGoals_SubGoalId",
            table: "HistoryRecords",
            column: "SubGoalId",
            principalTable: "SubGoals",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_SubTasks_Tasks_TaskId",
            table: "SubTasks",
            column: "TaskId",
            principalTable: "Tasks",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_HistoryRecords_SubGoals_SubGoalId",
            table: "HistoryRecords");

        migrationBuilder.DropForeignKey(
            name: "FK_SubTasks_Tasks_TaskId",
            table: "SubTasks");

        migrationBuilder.DropPrimaryKey(
            name: "PK_SubTasks",
            table: "SubTasks");

        migrationBuilder.DropPrimaryKey(
            name: "PK_HistoryRecords",
            table: "HistoryRecords");

        migrationBuilder.RenameTable(
            name: "SubTasks",
            newName: "SubTask");

        migrationBuilder.RenameTable(
            name: "HistoryRecords",
            newName: "HistoryRecord");

        migrationBuilder.RenameIndex(
            name: "IX_SubTasks_TaskId",
            table: "SubTask",
            newName: "IX_SubTask_TaskId");

        migrationBuilder.RenameIndex(
            name: "IX_HistoryRecords_SubGoalId",
            table: "HistoryRecord",
            newName: "IX_HistoryRecord_SubGoalId");

        migrationBuilder.AddPrimaryKey(
            name: "PK_SubTask",
            table: "SubTask",
            column: "Id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_HistoryRecord",
            table: "HistoryRecord",
            column: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_HistoryRecord_SubGoals_SubGoalId",
            table: "HistoryRecord",
            column: "SubGoalId",
            principalTable: "SubGoals",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_SubTask_Tasks_TaskId",
            table: "SubTask",
            column: "TaskId",
            principalTable: "Tasks",
            principalColumn: "Id");
    }
}
