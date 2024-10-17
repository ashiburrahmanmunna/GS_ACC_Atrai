using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class AccountHeadUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsItemBS",
                table: "AccountHead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsItemCS",
                table: "AccountHead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsItemPL",
                table: "AccountHead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsItemTA",
                table: "AccountHead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpDate",
                table: "AccountHead",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsItemBS",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "IsItemCS",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "IsItemPL",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "IsItemTA",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "OpDate",
                table: "AccountHead");
        }
    }
}
