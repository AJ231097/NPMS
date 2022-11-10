using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPMS.Migrations
{
    public partial class Careers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Careers",
                columns: table => new
                {
                    CareerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CareerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CareerDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CareerRecruiter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CareerPlace = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Careers", x => x.CareerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Careers");
        }
    }
}
