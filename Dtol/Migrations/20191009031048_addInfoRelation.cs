using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class addInfoRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "infoRelationShip",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HouseInfoId = table.Column<Guid>(nullable: true),
                    ResidentInfoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infoRelationShip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_infoRelationShip_houseInfo_HouseInfoId",
                        column: x => x.HouseInfoId,
                        principalTable: "houseInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_infoRelationShip_residentInfo_ResidentInfoId",
                        column: x => x.ResidentInfoId,
                        principalTable: "residentInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_infoRelationShip_HouseInfoId",
                table: "infoRelationShip",
                column: "HouseInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_infoRelationShip_ResidentInfoId",
                table: "infoRelationShip",
                column: "ResidentInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "infoRelationShip");
        }
    }
}
