using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updateExportInvoicePacking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceDetails_ExportInvoiceMaster_ExportInvoiceMasterId",
                table: "ExportInvoiceDetails");

            
            migrationBuilder.AlterColumn<int>(
                name: "ExportInvoiceMasterId",
                table: "ExportInvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoicePackingList_ExportInvoiceDetailsId",
                table: "ExportInvoicePackingList",
                column: "ExportInvoiceDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceDetails_ExportInvoiceMaster_ExportInvoiceMasterId",
                table: "ExportInvoiceDetails",
                column: "ExportInvoiceMasterId",
                principalTable: "ExportInvoiceMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            
            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoicePackingList_ExportInvoiceDetails_ExportInvoiceDetailsId",
                table: "ExportInvoicePackingList",
                column: "ExportInvoiceDetailsId",
                principalTable: "ExportInvoiceDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceDetails_ExportInvoiceMaster_ExportInvoiceMasterId",
                table: "ExportInvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_NotifyParty_SecondNotifyPartyId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoicePackingList_ExportInvoiceDetails_ExportInvoiceDetailsId",
                table: "ExportInvoicePackingList");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoicePackingList_ExportInvoiceDetailsId",
                table: "ExportInvoicePackingList");

            migrationBuilder.RenameColumn(
                name: "SecondNotifyPartyId",
                table: "ExportInvoiceMaster",
                newName: "SecoundNotifyPartyId");

            migrationBuilder.RenameIndex(
                name: "IX_ExportInvoiceMaster_SecondNotifyPartyId",
                table: "ExportInvoiceMaster",
                newName: "IX_ExportInvoiceMaster_SecoundNotifyPartyId");

            migrationBuilder.AlterColumn<int>(
                name: "ExportInvoiceMasterId",
                table: "ExportInvoiceDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceDetails_ExportInvoiceMaster_ExportInvoiceMasterId",
                table: "ExportInvoiceDetails",
                column: "ExportInvoiceMasterId",
                principalTable: "ExportInvoiceMaster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_NotifyParty_SecoundNotifyPartyId",
                table: "ExportInvoiceMaster",
                column: "SecoundNotifyPartyId",
                principalTable: "NotifyParty",
                principalColumn: "Id");
        }
    }
}
