using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updateexportInvoiceDetails : Migration
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

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceDetails_ExportInvoiceMaster_ExportInvoiceMasterId",
                table: "ExportInvoiceDetails",
                column: "ExportInvoiceMasterId",
                principalTable: "ExportInvoiceMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceDetails_ExportInvoiceMaster_ExportInvoiceMasterId",
                table: "ExportInvoiceDetails");

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
        }
    }
}
