using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class upadteBuilding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_residentRelationShip_ResidentInfoId",
                table: "residentRelationShip");

            migrationBuilder.DropIndex(
                name: "IX_infoRelationShip_ResidentInfoId",
                table: "infoRelationShip");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "building");

            migrationBuilder.CreateIndex(
                name: "IX_residentRelationShip_ResidentInfoId",
                table: "residentRelationShip",
                column: "ResidentInfoId",
                unique: true,
                filter: "[ResidentInfoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_infoRelationShip_ResidentInfoId",
                table: "infoRelationShip",
                column: "ResidentInfoId",
                unique: true,
                filter: "[ResidentInfoId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_residentRelationShip_ResidentInfoId",
                table: "residentRelationShip");

            migrationBuilder.DropIndex(
                name: "IX_infoRelationShip_ResidentInfoId",
                table: "infoRelationShip");

            migrationBuilder.AddColumn<Guid>(
                name: "AreaId",
                table: "building",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_residentRelationShip_ResidentInfoId",
                table: "residentRelationShip",
                column: "ResidentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_infoRelationShip_ResidentInfoId",
                table: "infoRelationShip",
                column: "ResidentInfoId");
        }
    }
}
