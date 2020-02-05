using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class upResidentInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelationWithHousehold",
                table: "residentInfo");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddTime",
                table: "residentInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddTime",
                table: "residentInfo");

            migrationBuilder.AddColumn<string>(
                name: "RelationWithHousehold",
                table: "residentInfo",
                nullable: true);
        }
    }
}
