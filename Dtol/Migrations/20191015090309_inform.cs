using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class inform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "inform",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InformTitle = table.Column<string>(nullable: true),
                    SendTime = table.Column<DateTime>(nullable: true),
                    Sender = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inform", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inform");
        }
    }
}
