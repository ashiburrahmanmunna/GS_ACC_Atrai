using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class approvalsettingschanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocApprovalSetting_UserAccount_LuserIdApprove",
                table: "DocApprovalSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_DocApprovalSetting_UserAccount_LuserIdCheck",
                table: "DocApprovalSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_DocApprovalSetting_UserAccount_LuserIdVerify",
                table: "DocApprovalSetting");

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdVerify",
                table: "DocApprovalSetting",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdCheck",
                table: "DocApprovalSetting",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdApprove",
                table: "DocApprovalSetting",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DocApprovalSetting_UserAccount_LuserIdApprove",
                table: "DocApprovalSetting",
                column: "LuserIdApprove",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocApprovalSetting_UserAccount_LuserIdCheck",
                table: "DocApprovalSetting",
                column: "LuserIdCheck",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocApprovalSetting_UserAccount_LuserIdVerify",
                table: "DocApprovalSetting",
                column: "LuserIdVerify",
                principalTable: "UserAccount",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocApprovalSetting_UserAccount_LuserIdApprove",
                table: "DocApprovalSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_DocApprovalSetting_UserAccount_LuserIdCheck",
                table: "DocApprovalSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_DocApprovalSetting_UserAccount_LuserIdVerify",
                table: "DocApprovalSetting");

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdVerify",
                table: "DocApprovalSetting",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdCheck",
                table: "DocApprovalSetting",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdApprove",
                table: "DocApprovalSetting",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DocApprovalSetting_UserAccount_LuserIdApprove",
                table: "DocApprovalSetting",
                column: "LuserIdApprove",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocApprovalSetting_UserAccount_LuserIdCheck",
                table: "DocApprovalSetting",
                column: "LuserIdCheck",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocApprovalSetting_UserAccount_LuserIdVerify",
                table: "DocApprovalSetting",
                column: "LuserIdVerify",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
