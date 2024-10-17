using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class tablenamechangeswithmodelname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat_BloodGroup_Company_ComId",
                table: "Cat_BloodGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Cat_BloodGroup_UserAccount_LuserId",
                table: "Cat_BloodGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Cat_PoliceStation_Company_ComId",
                table: "Cat_PoliceStation");

            migrationBuilder.DropForeignKey(
                name: "FK_Cat_PoliceStation_UserAccount_LuserId",
                table: "Cat_PoliceStation");

            migrationBuilder.DropForeignKey(
                name: "FK_Cat_Religion_Company_ComId",
                table: "Cat_Religion");

            migrationBuilder.DropForeignKey(
                name: "FK_Cat_Religion_UserAccount_LuserId",
                table: "Cat_Religion");

            migrationBuilder.DropIndex(
                name: "IX_Cat_Religion_ComId",
                table: "Cat_Religion");

            migrationBuilder.DropIndex(
                name: "IX_Cat_Religion_LuserId",
                table: "Cat_Religion");

            migrationBuilder.DropIndex(
                name: "IX_Cat_PoliceStation_ComId",
                table: "Cat_PoliceStation");

            migrationBuilder.DropIndex(
                name: "IX_Cat_PoliceStation_LuserId",
                table: "Cat_PoliceStation");

            migrationBuilder.DropIndex(
                name: "IX_Cat_BloodGroup_ComId",
                table: "Cat_BloodGroup");

            migrationBuilder.DropIndex(
                name: "IX_Cat_BloodGroup_LuserId",
                table: "Cat_BloodGroup");

            migrationBuilder.DropColumn(
                name: "DtInput",
                table: "Cat_Unit");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "Cat_Unit");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Cat_Religion");

            migrationBuilder.DropColumn(
                name: "DtInput",
                table: "Cat_Religion");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "Cat_Religion");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "Cat_Religion");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "Cat_Religion");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Cat_PoliceStation");

            migrationBuilder.DropColumn(
                name: "DtInput",
                table: "Cat_PoliceStation");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "Cat_PoliceStation");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "Cat_PoliceStation");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "Cat_PoliceStation");

            migrationBuilder.DropColumn(
                name: "DtInput",
                table: "Cat_Line");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "Cat_Line");

            migrationBuilder.DropColumn(
                name: "DtInput",
                table: "Cat_Grade");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "Cat_Grade");

            migrationBuilder.DropColumn(
                name: "DtInput",
                table: "Cat_Floor");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "Cat_Floor");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Cat_BloodGroup");

            migrationBuilder.DropColumn(
                name: "DtInput",
                table: "Cat_BloodGroup");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "Cat_BloodGroup");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "Cat_BloodGroup");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "Cat_BloodGroup");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DtInput",
                table: "Cat_Unit",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "Cat_Unit",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "Cat_Religion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInput",
                table: "Cat_Religion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "Cat_Religion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "Cat_Religion",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "Cat_Religion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "Cat_PoliceStation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInput",
                table: "Cat_PoliceStation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "Cat_PoliceStation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "Cat_PoliceStation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "Cat_PoliceStation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInput",
                table: "Cat_Line",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "Cat_Line",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInput",
                table: "Cat_Grade",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "Cat_Grade",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInput",
                table: "Cat_Floor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "Cat_Floor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "Cat_BloodGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInput",
                table: "Cat_BloodGroup",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "Cat_BloodGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "Cat_BloodGroup",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "Cat_BloodGroup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Religion_ComId",
                table: "Cat_Religion",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Religion_LuserId",
                table: "Cat_Religion",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PoliceStation_ComId",
                table: "Cat_PoliceStation",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PoliceStation_LuserId",
                table: "Cat_PoliceStation",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_BloodGroup_ComId",
                table: "Cat_BloodGroup",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_BloodGroup_LuserId",
                table: "Cat_BloodGroup",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_BloodGroup_Company_ComId",
                table: "Cat_BloodGroup",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_BloodGroup_UserAccount_LuserId",
                table: "Cat_BloodGroup",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_PoliceStation_Company_ComId",
                table: "Cat_PoliceStation",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_PoliceStation_UserAccount_LuserId",
                table: "Cat_PoliceStation",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_Religion_Company_ComId",
                table: "Cat_Religion",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_Religion_UserAccount_LuserId",
                table: "Cat_Religion",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
