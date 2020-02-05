using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class Activity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "activity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Theme = table.Column<string>(nullable: true),
                    ActivityForm = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    TargetPeople = table.Column<string>(nullable: true),
                    participantsNumber = table.Column<int>(nullable: true),
                    BeneficiaryNumber = table.Column<int>(nullable: true),
                    ActivityRecord = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activity");
        }
    }
}
