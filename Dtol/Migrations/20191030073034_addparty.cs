using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class addparty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "partyInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ResidentId = table.Column<Guid>(nullable: true),
                    IdNumber = table.Column<string>(nullable: true),
                    JoinPartyTime = table.Column<DateTime>(nullable: true),
                    PartyJob = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partyInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "partyInfo");
        }
    }
}
