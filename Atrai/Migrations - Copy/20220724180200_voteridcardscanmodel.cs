using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class voteridcardscanmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "dob",
                table: "Voter",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "presentAddressBN",
                table: "Voter",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "profession",
                table: "Voter",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "presentAddressBN",
                table: "Voter");

            migrationBuilder.DropColumn(
                name: "profession",
                table: "Voter");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dob",
                table: "Voter",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
