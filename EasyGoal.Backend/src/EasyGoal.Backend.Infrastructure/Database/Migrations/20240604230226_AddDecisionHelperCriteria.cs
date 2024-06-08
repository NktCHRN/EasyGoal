using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGoal.Backend.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddDecisionHelperCriteria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_PreferredDaysOfWeekRange_PreferredDaysOfWeekRang~",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_PreferredTimeSlotsRange_PreferredTimeSlotsRangeId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "PreferredDayOfWeek");

            migrationBuilder.DropTable(
                name: "PreferredTimeSlot");

            migrationBuilder.DropTable(
                name: "PreferredDaysOfWeekRange");

            migrationBuilder.DropTable(
                name: "PreferredTimeSlotsRange");

            migrationBuilder.DropIndex(
                name: "IX_Categories_PreferredDaysOfWeekRangeId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_PreferredTimeSlotsRangeId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "PreferredDaysOfWeekRangeId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PreferredTimeSlotsRangeId",
                table: "Categories");

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Tasks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DecisionHelperCriterion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false),
                    Type = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecisionHelperCriterion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DecisionHelperCriterion_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DecisionHelperCriterion_UserId",
                table: "DecisionHelperCriterion",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DecisionHelperCriterion");

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Tasks",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PreferredDaysOfWeekRangeId",
                table: "Categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PreferredTimeSlotsRangeId",
                table: "Categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PreferredDaysOfWeekRange",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferredDaysOfWeekRange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreferredTimeSlotsRange",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferredTimeSlotsRange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreferredDayOfWeek",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DayOfWeek = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    PreferredDaysOfWeekRangeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferredDayOfWeek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreferredDayOfWeek_PreferredDaysOfWeekRange_PreferredDaysOf~",
                        column: x => x.PreferredDaysOfWeekRangeId,
                        principalTable: "PreferredDaysOfWeekRange",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PreferredTimeSlot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    PreferredTimeSlotsRangeId = table.Column<Guid>(type: "uuid", nullable: true),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferredTimeSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreferredTimeSlot_PreferredTimeSlotsRange_PreferredTimeSlot~",
                        column: x => x.PreferredTimeSlotsRangeId,
                        principalTable: "PreferredTimeSlotsRange",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PreferredDaysOfWeekRangeId",
                table: "Categories",
                column: "PreferredDaysOfWeekRangeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PreferredTimeSlotsRangeId",
                table: "Categories",
                column: "PreferredTimeSlotsRangeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreferredDayOfWeek_PreferredDaysOfWeekRangeId",
                table: "PreferredDayOfWeek",
                column: "PreferredDaysOfWeekRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_PreferredTimeSlot_PreferredTimeSlotsRangeId",
                table: "PreferredTimeSlot",
                column: "PreferredTimeSlotsRangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_PreferredDaysOfWeekRange_PreferredDaysOfWeekRang~",
                table: "Categories",
                column: "PreferredDaysOfWeekRangeId",
                principalTable: "PreferredDaysOfWeekRange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_PreferredTimeSlotsRange_PreferredTimeSlotsRangeId",
                table: "Categories",
                column: "PreferredTimeSlotsRangeId",
                principalTable: "PreferredTimeSlotsRange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
