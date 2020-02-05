using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class recreatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "residentialAreas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Developers = table.Column<string>(nullable: true),
                    Property = table.Column<string>(nullable: true),
                    ConstructionTime = table.Column<DateTime>(nullable: true),
                    PropertyFee = table.Column<double>(nullable: true),
                    PropertyContacts = table.Column<string>(nullable: true),
                    Telephone = table.Column<int>(nullable: true),
                    BuiltUpArea = table.Column<double>(nullable: true),
                    ParkingSpacesAbove = table.Column<int>(nullable: true),
                    ParkingSpacesBelow = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    East = table.Column<string>(nullable: true),
                    South = table.Column<string>(nullable: true),
                    West = table.Column<string>(nullable: true),
                    North = table.Column<string>(nullable: true),
                    Status1 = table.Column<string>(nullable: true)
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
