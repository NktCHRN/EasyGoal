using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGoal.Backend.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class AddSubGoalGoalNavigation : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_SubGoals_Goals_GoalId",
            table: "SubGoals");

        migrationBuilder.AlterColumn<Guid>(
            name: "GoalId",
            table: "SubGoals",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldNullable: true);

        migrationBuilder.AddForeignKey(
            name: "FK_SubGoals_Goals_GoalId",
            table: "SubGoals",
            column: "GoalId",
            principalTable: "Goals",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_SubGoals_Goals_GoalId",
            table: "SubGoals");

        migrationBuilder.AlterColumn<Guid>(
            name: "GoalId",
            table: "SubGoals",
            type: "uuid",
            nullable: true,
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AddForeignKey(
            name: "FK_SubGoals_Goals_GoalId",
            table: "SubGoals",
            column: "GoalId",
            principalTable: "Goals",
            principalColumn: "Id");
    }
}
