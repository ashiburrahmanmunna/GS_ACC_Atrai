using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class userterminatemodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NewExpiredDate",
                table: "UserTerminate",
                newName: "TerminateDate");

            migrationBuilder.AddColumn<string>(
                name: "DeviceUpdate",
                table: "UserTerminate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNoIfNecessary",
                table: "UserTerminate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextFollowDate",
                table: "UserTerminate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceUpdate",
                table: "UserTerminate");

            migrationBuilder.DropColumn(
                name: "MobileNoIfNecessary",
                table: "UserTerminate");

            migrationBuilder.DropColumn(
                name: "NextFollowDate",
                table: "UserTerminate");

            migrationBuilder.RenameColumn(
                name: "TerminateDate",
                table: "UserTerminate",
                newName: "NewExpiredDate");
        }
    }
}
