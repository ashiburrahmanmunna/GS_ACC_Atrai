using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class Receivedbyhead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReceivedDate",
                table: "InvoiceBill",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "AccountReceiveByHeadId",
                table: "InvoiceBill",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountReceiveHeadId",
                table: "InvoiceBill",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceBill_AccountReceiveByHeadId",
                table: "InvoiceBill",
                column: "AccountReceiveByHeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceBill_AccountHead_AccountReceiveByHeadId",
                table: "InvoiceBill",
                column: "AccountReceiveByHeadId",
                principalTable: "AccountHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceBill_AccountHead_AccountReceiveByHeadId",
                table: "InvoiceBill");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceBill_AccountReceiveByHeadId",
                table: "InvoiceBill");

            migrationBuilder.DropColumn(
                name: "AccountReceiveByHeadId",
                table: "InvoiceBill");

            migrationBuilder.DropColumn(
                name: "AccountReceiveHeadId",
                table: "InvoiceBill");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReceivedDate",
                table: "InvoiceBill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
