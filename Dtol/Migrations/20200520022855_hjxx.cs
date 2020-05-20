using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class hjxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "houseInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "houseInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "houseInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "houseInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Register",
                table: "houseInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "houseInfo");

            migrationBuilder.DropColumn(
                name: "City",
                table: "houseInfo");

            migrationBuilder.DropColumn(
                name: "County",
                table: "houseInfo");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "houseInfo");

            migrationBuilder.DropColumn(
                name: "Register",
                table: "houseInfo");
        }
    }
}
