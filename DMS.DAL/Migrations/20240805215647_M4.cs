using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class M4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Start",
                table: "shifts",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "shifts",
                newName: "EndTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "shifts",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "shifts",
                newName: "End");
        }
    }
}
