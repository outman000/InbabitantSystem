using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class informAndResident : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "informAndResident",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InformId = table.Column<Guid>(nullable: true),
                    residentInfoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_informAndResident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_informAndResident_inform_InformId",
                        column: x => x.InformId,
                        principalTable: "inform",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_informAndResident_residentInfo_residentInfoId",
                        column: x => x.residentInfoId,
                        principalTable: "residentInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_informAndResident_InformId",
                table: "informAndResident",
                column: "InformId");

            migrationBuilder.CreateIndex(
                name: "IX_informAndResident_residentInfoId",
                table: "informAndResident",
                column: "residentInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "informAndResident");
        }
    }
}
