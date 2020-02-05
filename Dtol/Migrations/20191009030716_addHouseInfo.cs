using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class addHouseInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "houseInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HouseHolder = table.Column<string>(nullable: true),
                    HouseHolderIdNo = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    BuildingNo = table.Column<int>(nullable: true),
                    UnitNo = table.Column<int>(nullable: true),
                    HouseNo = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_houseInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "houseInfo");
        }
    }
}
