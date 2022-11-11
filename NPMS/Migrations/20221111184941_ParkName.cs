using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPMS.Migrations
{
    public partial class ParkName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParkName",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParkName",
                table: "Reservations");
        }
    }
}
