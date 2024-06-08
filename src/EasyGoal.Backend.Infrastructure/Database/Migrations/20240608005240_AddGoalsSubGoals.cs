using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGoal.Backend.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class AddGoalsSubGoals : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_FileAttachments_AspNetUsers_UserId",
            table: "FileAttachments");

        migrationBuilder.DropForeignKey(
            name: "FK_FileAttachments_Goals_GoalId",
            table: "FileAttachments");

        migrationBuilder.DropIndex(
            name: "IX_FileAttachments_UserId",
            table: "FileAttachments");

        migrationBuilder.DropColumn(
            name: "IsDone",
            table: "Tasks");

        migrationBuilder.DropColumn(
            name: "UserId",
            table: "FileAttachments");

        migrationBuilder.AddColumn<Guid>(
            name: "SubGoalId",
            table: "Tasks",
            type: "uuid",
            nullable: true);

        migrationBuilder.AddColumn<DateTimeOffset>(
            name: "Deadline",
            table: "Goals",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

        migrationBuilder.AddColumn<string>(
            name: "Description",
            table: "Goals",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Name",
            table: "Goals",
            type: "character varying(256)",
            maxLength: 256,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "PictureLocalFileName",
            table: "Goals",
            type: "character varying(256)",
            maxLength: 256,
            nullable: true);

        migrationBuilder.AlterColumn<Guid>(
            name: "GoalId",
            table: "FileAttachments",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldNullable: true);

        migrationBuilder.CreateTable(
            name: "SubGoals",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                Deadline = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                GoalId = table.Column<Guid>(type: "uuid", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                CreatedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                ModifiedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SubGoals", x => x.Id);
                table.ForeignKey(
                    name: "FK_SubGoals_Goals_GoalId",
                    column: x => x.GoalId,
                    principalTable: "Goals",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "HistoryRecord",
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
                table.PrimaryKey("PK_HistoryRecord", x => x.Id);
                table.ForeignKey(
                    name: "FK_HistoryRecord_SubGoals_SubGoalId",
                    column: x => x.SubGoalId,
                    principalTable: "SubGoals",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Tasks_SubGoalId",
            table: "Tasks",
            column: "SubGoalId");

        migrationBuilder.CreateIndex(
            name: "IX_Goals_UserId",
            table: "Goals",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_HistoryRecord_SubGoalId",
            table: "HistoryRecord",
            column: "SubGoalId");

        migrationBuilder.CreateIndex(
            name: "IX_SubGoals_GoalId",
            table: "SubGoals",
            column: "GoalId");

        migrationBuilder.AddForeignKey(
            name: "FK_FileAttachments_Goals_GoalId",
            table: "FileAttachments",
            column: "GoalId",
            principalTable: "Goals",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Goals_AspNetUsers_UserId",
            table: "Goals",
            column: "UserId",
            principalTable: "AspNetUsers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Tasks_SubGoals_SubGoalId",
            table: "Tasks",
            column: "SubGoalId",
            principalTable: "SubGoals",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_FileAttachments_Goals_GoalId",
            table: "FileAttachments");

        migrationBuilder.DropForeignKey(
            name: "FK_Goals_AspNetUsers_UserId",
            table: "Goals");

        migrationBuilder.DropForeignKey(
            name: "FK_Tasks_SubGoals_SubGoalId",
            table: "Tasks");

        migrationBuilder.DropTable(
            name: "HistoryRecord");

        migrationBuilder.DropTable(
            name: "SubGoals");

        migrationBuilder.DropIndex(
            name: "IX_Tasks_SubGoalId",
            table: "Tasks");

        migrationBuilder.DropIndex(
            name: "IX_Goals_UserId",
            table: "Goals");

        migrationBuilder.DropColumn(
            name: "SubGoalId",
            table: "Tasks");

        migrationBuilder.DropColumn(
            name: "Deadline",
            table: "Goals");

        migrationBuilder.DropColumn(
            name: "Description",
            table: "Goals");

        migrationBuilder.DropColumn(
            name: "Name",
            table: "Goals");

        migrationBuilder.DropColumn(
            name: "PictureLocalFileName",
            table: "Goals");

        migrationBuilder.AddColumn<bool>(
            name: "IsDone",
            table: "Tasks",
            type: "boolean",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AlterColumn<Guid>(
            name: "GoalId",
            table: "FileAttachments",
            type: "uuid",
            nullable: true,
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AddColumn<Guid>(
            name: "UserId",
            table: "FileAttachments",
            type: "uuid",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_FileAttachments_UserId",
            table: "FileAttachments",
            column: "UserId");

        migrationBuilder.AddForeignKey(
            name: "FK_FileAttachments_AspNetUsers_UserId",
            table: "FileAttachments",
            column: "UserId",
            principalTable: "AspNetUsers",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_FileAttachments_Goals_GoalId",
            table: "FileAttachments",
            column: "GoalId",
            principalTable: "Goals",
            principalColumn: "Id");
    }
}
