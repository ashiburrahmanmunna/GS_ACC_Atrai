using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class verifybypurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApproveDate",
                table: "Purchase",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckDate",
                table: "Purchase",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdApprove",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdCheck",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdVerify",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VerifyDate",
                table: "Purchase",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_LuserIdApprove",
                table: "Purchase",
                column: "LuserIdApprove");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_LuserIdCheck",
                table: "Purchase",
                column: "LuserIdCheck");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_LuserIdVerify",
                table: "Purchase",
                column: "LuserIdVerify");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_UserAccount_LuserIdApprove",
                table: "Purchase",
                column: "LuserIdApprove",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_UserAccount_LuserIdCheck",
                table: "Purchase",
                column: "LuserIdCheck",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_UserAccount_LuserIdVerify",
                table: "Purchase",
                column: "LuserIdVerify",
                principalTable: "UserAccount",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_UserAccount_LuserIdApprove",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_UserAccount_LuserIdCheck",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_UserAccount_LuserIdVerify",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_LuserIdApprove",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_LuserIdCheck",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_LuserIdVerify",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "ApproveDate",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "CheckDate",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "LuserIdApprove",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "LuserIdCheck",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "LuserIdVerify",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "VerifyDate",
                table: "Purchase");
        }
    }
}
