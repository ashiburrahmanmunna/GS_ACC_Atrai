using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updateexportInvoiceDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_NotifyParty_SecoundNotifyPartyId",
                table: "ExportInvoiceMaster");

            migrationBuilder.RenameColumn(
                name: "SecoundNotifyPartyId",
                table: "ExportInvoiceMaster",
                newName: "SecondNotifyPartyId");

            migrationBuilder.RenameIndex(
                name: "IX_ExportInvoiceMaster_SecoundNotifyPartyId",
                table: "ExportInvoiceMaster",
                newName: "IX_ExportInvoiceMaster_SecondNotifyPartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_NotifyParty_SecondNotifyPartyId",
                table: "ExportInvoiceMaster",
                column: "SecondNotifyPartyId",
                principalTable: "NotifyParty",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_NotifyParty_SecondNotifyPartyId",
                table: "ExportInvoiceMaster");

            migrationBuilder.RenameColumn(
                name: "SecondNotifyPartyId",
                table: "ExportInvoiceMaster",
                newName: "SecoundNotifyPartyId");

            migrationBuilder.RenameIndex(
                name: "IX_ExportInvoiceMaster_SecondNotifyPartyId",
                table: "ExportInvoiceMaster",
                newName: "IX_ExportInvoiceMaster_SecoundNotifyPartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_NotifyParty_SecoundNotifyPartyId",
                table: "ExportInvoiceMaster",
                column: "SecoundNotifyPartyId",
                principalTable: "NotifyParty",
                principalColumn: "Id");
        }
    }
}
