using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class somechangestoday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PcName",
                table: "Cat_District");

            migrationBuilder.RenameColumn(
                name: "PayModeId",
                table: "Cat_PayMode",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AccTypeId",
                table: "Cat_AccountType",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Cat_PayMode",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Cat_PayMode",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Cat_PayMode",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Cat_AccountType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Cat_AccountType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Cat_AccountType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Cat_PayMode");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Cat_PayMode");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Cat_PayMode");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Cat_AccountType");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Cat_AccountType");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Cat_AccountType");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cat_PayMode",
                newName: "PayModeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cat_AccountType",
                newName: "AccTypeId");

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "Cat_District",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
