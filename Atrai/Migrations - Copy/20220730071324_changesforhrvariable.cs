using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class changesforhrvariable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "HR_Emp_Nominee");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "HR_Emp_Nominee");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "HR_Emp_Nominee");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "HR_Emp_Nominee");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "HR_Emp_Family");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "HR_Emp_Family");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "HR_Emp_Family");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "HR_Emp_Family");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "HR_Emp_Experience");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "HR_Emp_Experience");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "HR_Emp_Experience");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "HR_Emp_Experience");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "HR_Emp_Education");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "HR_Emp_Education");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "HR_Emp_Education");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "HR_Emp_Education");

            migrationBuilder.RenameColumn(
                name: "EmpPersInfoId",
                table: "HR_Emp_PersonalInfo",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmpNomId",
                table: "HR_Emp_Nominee",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmpFamilyId",
                table: "HR_Emp_Family",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmpExpId",
                table: "HR_Emp_Experience",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmpEduId",
                table: "HR_Emp_Education",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "HR_Emp_PersonalInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "HR_Emp_PersonalInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "HR_Emp_PersonalInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "HR_Emp_PersonalInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "HR_Emp_Nominee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "HR_Emp_Nominee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "HR_Emp_Nominee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "HR_Emp_Nominee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "HR_Emp_Family",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "HR_Emp_Family",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "HR_Emp_Family",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "HR_Emp_Family",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "HR_Emp_Experience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "HR_Emp_Experience",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "HR_Emp_Experience",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "HR_Emp_Experience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "HR_Emp_Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "HR_Emp_Education",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "HR_Emp_Education",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "HR_Emp_Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PersonalInfo_ComId",
                table: "HR_Emp_PersonalInfo",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PersonalInfo_LuserId",
                table: "HR_Emp_PersonalInfo",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Nominee_ComId",
                table: "HR_Emp_Nominee",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Nominee_LuserId",
                table: "HR_Emp_Nominee",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Family_ComId",
                table: "HR_Emp_Family",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Family_LuserId",
                table: "HR_Emp_Family",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Experience_ComId",
                table: "HR_Emp_Experience",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Experience_LuserId",
                table: "HR_Emp_Experience",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Education_ComId",
                table: "HR_Emp_Education",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Education_LuserId",
                table: "HR_Emp_Education",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Education_Company_ComId",
                table: "HR_Emp_Education",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Education_UserAccount_LuserId",
                table: "HR_Emp_Education",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Experience_Company_ComId",
                table: "HR_Emp_Experience",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Experience_UserAccount_LuserId",
                table: "HR_Emp_Experience",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Family_Company_ComId",
                table: "HR_Emp_Family",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Family_UserAccount_LuserId",
                table: "HR_Emp_Family",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Nominee_Company_ComId",
                table: "HR_Emp_Nominee",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Nominee_UserAccount_LuserId",
                table: "HR_Emp_Nominee",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_PersonalInfo_Company_ComId",
                table: "HR_Emp_PersonalInfo",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_PersonalInfo_UserAccount_LuserId",
                table: "HR_Emp_PersonalInfo",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Education_Company_ComId",
                table: "HR_Emp_Education");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Education_UserAccount_LuserId",
                table: "HR_Emp_Education");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Experience_Company_ComId",
                table: "HR_Emp_Experience");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Experience_UserAccount_LuserId",
                table: "HR_Emp_Experience");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Family_Company_ComId",
                table: "HR_Emp_Family");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Family_UserAccount_LuserId",
                table: "HR_Emp_Family");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Nominee_Company_ComId",
                table: "HR_Emp_Nominee");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Nominee_UserAccount_LuserId",
                table: "HR_Emp_Nominee");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_PersonalInfo_Company_ComId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_PersonalInfo_UserAccount_LuserId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_PersonalInfo_ComId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_PersonalInfo_LuserId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Nominee_ComId",
                table: "HR_Emp_Nominee");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Nominee_LuserId",
                table: "HR_Emp_Nominee");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Family_ComId",
                table: "HR_Emp_Family");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Family_LuserId",
                table: "HR_Emp_Family");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Experience_ComId",
                table: "HR_Emp_Experience");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Experience_LuserId",
                table: "HR_Emp_Experience");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Education_ComId",
                table: "HR_Emp_Education");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Education_LuserId",
                table: "HR_Emp_Education");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "HR_Emp_Nominee");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "HR_Emp_Nominee");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "HR_Emp_Nominee");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "HR_Emp_Nominee");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "HR_Emp_Family");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "HR_Emp_Family");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "HR_Emp_Family");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "HR_Emp_Family");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "HR_Emp_Experience");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "HR_Emp_Experience");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "HR_Emp_Experience");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "HR_Emp_Experience");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "HR_Emp_Education");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "HR_Emp_Education");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "HR_Emp_Education");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "HR_Emp_Education");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HR_Emp_PersonalInfo",
                newName: "EmpPersInfoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HR_Emp_Nominee",
                newName: "EmpNomId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HR_Emp_Family",
                newName: "EmpFamilyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HR_Emp_Experience",
                newName: "EmpExpId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HR_Emp_Education",
                newName: "EmpEduId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "HR_Emp_PersonalInfo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "HR_Emp_PersonalInfo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "HR_Emp_PersonalInfo",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "HR_Emp_PersonalInfo",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "HR_Emp_Nominee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "HR_Emp_Nominee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "HR_Emp_Nominee",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "HR_Emp_Nominee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "HR_Emp_Family",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "HR_Emp_Family",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "HR_Emp_Family",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "HR_Emp_Family",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "HR_Emp_Experience",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "HR_Emp_Experience",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "HR_Emp_Experience",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "HR_Emp_Experience",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "HR_Emp_Education",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "HR_Emp_Education",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "HR_Emp_Education",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "HR_Emp_Education",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
