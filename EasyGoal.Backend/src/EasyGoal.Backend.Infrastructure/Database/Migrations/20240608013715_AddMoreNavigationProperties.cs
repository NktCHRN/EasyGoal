using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGoal.Backend.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class AddMoreNavigationProperties : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_SubTasks_Tasks_TaskId",
            table: "SubTasks");

        migrationBuilder.DropForeignKey(
            name: "FK_Tasks_SubGoals_SubGoalId",
            table: "Tasks");

        migrationBuilder.AlterColumn<Guid>(
            name: "SubGoalId",
            table: "Tasks",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldNullable: true);

        migrationBuilder.AlterColumn<Guid>(
            name: "TaskId",
            table: "SubTasks",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldNullable: true);

        migrationBuilder.AddForeignKey(
            name: "FK_SubTasks_Tasks_TaskId",
            table: "SubTasks",
            column: "TaskId",
            principalTable: "Tasks",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Tasks_SubGoals_SubGoalId",
            table: "Tasks",
            column: "SubGoalId",
            principalTable: "SubGoals",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_SubTasks_Tasks_TaskId",
            table: "SubTasks");

        migrationBuilder.DropForeignKey(
            name: "FK_Tasks_SubGoals_SubGoalId",
            table: "Tasks");

        migrationBuilder.AlterColumn<Guid>(
            name: "SubGoalId",
            table: "Tasks",
            type: "uuid",
            nullable: true,
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AlterColumn<Guid>(
            name: "TaskId",
            table: "SubTasks",
            type: "uuid",
            nullable: true,
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AddForeignKey(
            name: "FK_SubTasks_Tasks_TaskId",
            table: "SubTasks",
            column: "TaskId",
            principalTable: "Tasks",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Tasks_SubGoals_SubGoalId",
            table: "Tasks",
            column: "SubGoalId",
            principalTable: "SubGoals",
            principalColumn: "Id");
    }
}
