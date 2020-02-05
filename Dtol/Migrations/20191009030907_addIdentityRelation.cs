using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class addIdentityRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "residentRelationShip",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ResidentInfoId = table.Column<Guid>(nullable: true),
                    ResidentIdentityId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_residentRelationShip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_residentRelationShip_residentIdentity_ResidentIdentityId",
                        column: x => x.ResidentIdentityId,
                        principalTable: "residentIdentity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_residentRelationShip_residentInfo_ResidentInfoId",
                        column: x => x.ResidentInfoId,
                        principalTable: "residentInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_residentRelationShip_ResidentIdentityId",
                table: "residentRelationShip",
                column: "ResidentIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_residentRelationShip_ResidentInfoId",
                table: "residentRelationShip",
                column: "ResidentInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "residentRelationShip");
        }
    }
}
