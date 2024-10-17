using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class ChecknoTransactionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CheckNo",
                table: "AccountsDailyTransaction",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckRemarks",
                table: "AccountsDailyTransaction",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dtClearChk",
                table: "AccountsDailyTransaction",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dtFromChk",
                table: "AccountsDailyTransaction",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dtToChk",
                table: "AccountsDailyTransaction",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckNo",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "CheckRemarks",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "dtClearChk",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "dtFromChk",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "dtToChk",
                table: "AccountsDailyTransaction");
        }
    }
}
