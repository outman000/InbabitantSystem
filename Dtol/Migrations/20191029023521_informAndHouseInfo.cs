using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class informAndHouseInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddTime",
                table: "inform",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddTime",
                table: "houseInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddTime",
                table: "inform");

            migrationBuilder.DropColumn(
                name: "AddTime",
                table: "houseInfo");
        }
    }
}
