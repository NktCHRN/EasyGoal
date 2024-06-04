using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGoal.Backend.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddDecisionHelperCriteriaTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DecisionHelperCriterion_AspNetUsers_UserId",
                table: "DecisionHelperCriterion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DecisionHelperCriterion",
                table: "DecisionHelperCriterion");

            migrationBuilder.RenameTable(
                name: "DecisionHelperCriterion",
                newName: "DecisionHelperCriteria");

            migrationBuilder.RenameIndex(
                name: "IX_DecisionHelperCriterion_UserId",
                table: "DecisionHelperCriteria",
                newName: "IX_DecisionHelperCriteria_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DecisionHelperCriteria",
                table: "DecisionHelperCriteria",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DecisionHelperCriteria_AspNetUsers_UserId",
                table: "DecisionHelperCriteria",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DecisionHelperCriteria_AspNetUsers_UserId",
                table: "DecisionHelperCriteria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DecisionHelperCriteria",
                table: "DecisionHelperCriteria");

            migrationBuilder.RenameTable(
                name: "DecisionHelperCriteria",
                newName: "DecisionHelperCriterion");

            migrationBuilder.RenameIndex(
                name: "IX_DecisionHelperCriteria_UserId",
                table: "DecisionHelperCriterion",
                newName: "IX_DecisionHelperCriterion_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DecisionHelperCriterion",
                table: "DecisionHelperCriterion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DecisionHelperCriterion_AspNetUsers_UserId",
                table: "DecisionHelperCriterion",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
