using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class building : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "building",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AreaId = table.Column<Guid>(nullable: true),
                    AreaInfoId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    BuildingNo = table.Column<int>(nullable: true),
                    UnitNo = table.Column<int>(nullable: true),
                    FloorCount = table.Column<int>(nullable: true),
                    ElevatorCount = table.Column<int>(nullable: true),
                    HouseCount = table.Column<int>(nullable: true),
                    ConstructionTime = table.Column<DateTime>(nullable: true),
                    CheckinTime = table.Column<DateTime>(nullable: true),
                    BuildingNature = table.Column<string>(nullable: true),
                    UndergroundCount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_building", x => x.Id);
                    table.ForeignKey(
                        name: "FK_building_residentialAreas_AreaInfoId",
                        column: x => x.AreaInfoId,
                        principalTable: "residentialAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_building_AreaInfoId",
                table: "building",
                column: "AreaInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "building");
        }
    }
}
