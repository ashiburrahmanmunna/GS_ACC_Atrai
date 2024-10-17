using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class EmployeeViewPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat_PostOffice_Company_ComId",
                table: "Cat_PostOffice");

            migrationBuilder.DropForeignKey(
                name: "FK_Cat_PostOffice_UserAccount_LuserId",
                table: "Cat_PostOffice");

            migrationBuilder.DropIndex(
                name: "IX_Cat_PostOffice_ComId",
                table: "Cat_PostOffice");

            migrationBuilder.DropIndex(
                name: "IX_Cat_PostOffice_LuserId",
                table: "Cat_PostOffice");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Cat_PostOffice");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "Cat_PostOffice");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "Cat_PostOffice");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Cat_Leave_Type");

            migrationBuilder.DropColumn(
                name: "DtInput",
                table: "Cat_BuildingType");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "Cat_BuildingType");

            migrationBuilder.RenameColumn(
                name: "LTypeId",
                table: "Cat_Leave_Type",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Cat_Leave_Type",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Cat_Leave_Type",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Cat_Leave_Type",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Cat_Leave_Type");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Cat_Leave_Type");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Cat_Leave_Type");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cat_Leave_Type",
                newName: "LTypeId");

            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "Cat_PostOffice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "Cat_PostOffice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "Cat_PostOffice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "Cat_Leave_Type",
                type: "int",
                maxLength: 80,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInput",
                table: "Cat_BuildingType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "Cat_BuildingType",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PostOffice_ComId",
                table: "Cat_PostOffice",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PostOffice_LuserId",
                table: "Cat_PostOffice",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_PostOffice_Company_ComId",
                table: "Cat_PostOffice",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_PostOffice_UserAccount_LuserId",
                table: "Cat_PostOffice",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
