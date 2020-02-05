using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class _191111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddTime",
                table: "residentIdentity",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "FormId",
                table: "fileUpload",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddTime",
                table: "fileUpload",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "fileUpload",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddTime",
                table: "residentIdentity");

            migrationBuilder.DropColumn(
                name: "AddTime",
                table: "fileUpload");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "fileUpload");

            migrationBuilder.AlterColumn<Guid>(
                name: "FormId",
                table: "fileUpload",
                nullable: true,
                oldClrType: typeof(Guid));
        }
    }
}
