using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class createResidentialArea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "residentialAreas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nanme = table.Column<string>(nullable: true),
                    Developers = table.Column<string>(nullable: true),
                    Property = table.Column<string>(nullable: true),
                    ConstructionTime = table.Column<DateTime>(nullable: false),
                    PropertyFee = table.Column<double>(nullable: false),
                    PropertyContacts = table.Column<string>(nullable: true),
                    Telephone = table.Column<int>(nullable: false),
                    BuiltUpArea = table.Column<double>(nullable: false),
                    ParkingSpacesAbove = table.Column<int>(nullable: false),
                    ParkingSpacesBelow = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    East = table.Column<string>(nullable: true),
                    South = table.Column<string>(nullable: true),
                    West = table.Column<string>(nullable: true),
                    North = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_residentialAreas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "residentialAreas");
        }
    }
}
