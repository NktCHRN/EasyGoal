using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGoal.Backend.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIsSynchronisedWithGoogleName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsSynchonisedWithGoogle",
                table: "Tasks",
                newName: "GoogleSynchronisationStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GoogleSynchronisationStatus",
                table: "Tasks",
                newName: "IsSynchonisedWithGoogle");
        }
    }
}
