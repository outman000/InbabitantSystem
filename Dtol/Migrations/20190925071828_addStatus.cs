using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class addStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nanme",
                table: "residentialAreas",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Stauts",
                table: "residentialAreas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "residentialAreas");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "residentialAreas",
                newName: "Nanme");
        }
    }
}
