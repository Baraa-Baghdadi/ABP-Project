using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.FirstProjet.Migrations
{
    /// <inheritdoc />
    public partial class addFullMobileNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullMobileNumber",
                table: "AppPatients",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullMobileNumber",
                table: "AppPatients");
        }
    }
}
