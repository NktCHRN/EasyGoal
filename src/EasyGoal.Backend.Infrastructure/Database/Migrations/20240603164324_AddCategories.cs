using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGoal.Backend.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    PreferredDaysOfWeekRangeId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ColorHex = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PreferredDaysOfWeekRangeId = table.Column<Guid>(type: "uuid", nullable: false),
                    PreferredTimeSlotsRangeId = table.Column<Guid>(type: "uuid", nullable: false),
                    IdentityApplicationUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_IdentityApplicationUserId",
                        column: x => x.IdentityApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories_PreferredDaysOfWeekRange_PreferredDaysOfWeekRang~",
                        column: x => x.PreferredDaysOfWeekRangeId,
                        principalTable: "PreferredDaysOfWeekRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_PreferredTimeSlotsRange_PreferredTimeSlotsRangeId",
                        column: x => x.PreferredTimeSlotsRangeId,
                        principalTable: "PreferredTimeSlotsRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreferredTimeSlot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    PreferredTimeSlotsRangeId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "IX_Categories_IdentityApplicationUserId",
                table: "Categories",
                column: "IdentityApplicationUserId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "PreferredDayOfWeek");

            migrationBuilder.DropTable(
                name: "PreferredTimeSlot");

            migrationBuilder.DropTable(
                name: "PreferredDaysOfWeekRange");

            migrationBuilder.DropTable(
                name: "PreferredTimeSlotsRange");
        }
    }
}
