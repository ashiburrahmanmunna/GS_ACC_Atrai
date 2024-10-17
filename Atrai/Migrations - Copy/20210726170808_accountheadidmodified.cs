using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class accountheadidmodified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceBill_AccountReceiveHeadId",
                table: "InvoiceBill",
                column: "AccountReceiveHeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceBill_AccountHead_AccountReceiveHeadId",
                table: "InvoiceBill",
                column: "AccountReceiveHeadId",
                principalTable: "AccountHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceBill_AccountHead_AccountReceiveHeadId",
                table: "InvoiceBill");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceBill_AccountReceiveHeadId",
                table: "InvoiceBill");

            migrationBuilder.AddColumn<int>(
                name: "AccountReceiveByHeadId",
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
    }
}
