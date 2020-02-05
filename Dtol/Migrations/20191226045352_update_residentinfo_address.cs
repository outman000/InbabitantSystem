using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class update_residentinfo_address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "residentInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "residentInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "residentInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "residentInfo");

            migrationBuilder.DropColumn(
                name: "County",
                table: "residentInfo");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "residentInfo");
        }
    }
}
