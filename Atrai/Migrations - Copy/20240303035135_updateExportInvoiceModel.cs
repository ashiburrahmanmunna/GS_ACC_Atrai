using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updateExportInvoiceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FirstNotifyPartyId",
                table: "ExportInvoiceMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecoundNotifyPartyId",
                table: "ExportInvoiceMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThirdNotifyPartyId",
                table: "ExportInvoiceMaster",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_FirstNotifyPartyId",
                table: "ExportInvoiceMaster",
                column: "FirstNotifyPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_SecoundNotifyPartyId",
                table: "ExportInvoiceMaster",
                column: "SecoundNotifyPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_ThirdNotifyPartyId",
                table: "ExportInvoiceMaster",
                column: "ThirdNotifyPartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_NotifyParty_FirstNotifyPartyId",
                table: "ExportInvoiceMaster",
                column: "FirstNotifyPartyId",
                principalTable: "NotifyParty",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_NotifyParty_SecoundNotifyPartyId",
                table: "ExportInvoiceMaster",
                column: "SecoundNotifyPartyId",
                principalTable: "NotifyParty",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_NotifyParty_ThirdNotifyPartyId",
                table: "ExportInvoiceMaster",
                column: "ThirdNotifyPartyId",
                principalTable: "NotifyParty",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_NotifyParty_FirstNotifyPartyId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_NotifyParty_SecoundNotifyPartyId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_NotifyParty_ThirdNotifyPartyId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoiceMaster_FirstNotifyPartyId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoiceMaster_SecoundNotifyPartyId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoiceMaster_ThirdNotifyPartyId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropColumn(
                name: "FirstNotifyPartyId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropColumn(
                name: "SecoundNotifyPartyId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropColumn(
                name: "ThirdNotifyPartyId",
                table: "ExportInvoiceMaster");
        }
    }
}
