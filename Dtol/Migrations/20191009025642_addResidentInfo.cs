using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class addResidentInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "residentInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Minority = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Married = table.Column<string>(nullable: true),
                    Politics = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    IdNumber = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Register = table.Column<string>(nullable: true),
                    Education = table.Column<string>(nullable: true),
                    RelationWithHousehold = table.Column<string>(nullable: true),
                    HouseHolderId = table.Column<Guid>(nullable: true),
                    ReligiousBelief = table.Column<string>(nullable: true),
                    Job = table.Column<string>(nullable: true),
                    PhotoId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_residentInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "residentInfo");
        }
    }
}
