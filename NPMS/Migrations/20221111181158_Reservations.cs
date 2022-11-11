using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPMS.Migrations
{
    public partial class Reservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Rid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfEvent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Rid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
