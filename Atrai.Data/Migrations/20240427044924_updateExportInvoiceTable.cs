using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateExportInvoiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "ExportInvoiceMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShipModelId",
                table: "ExportInvoiceMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TradeTermId",
                table: "ExportInvoiceMaster",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_DestinationId",
                table: "ExportInvoiceMaster",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_ShipModelId",
                table: "ExportInvoiceMaster",
                column: "ShipModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_TradeTermId",
                table: "ExportInvoiceMaster",
                column: "TradeTermId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_Destination_DestinationId",
                table: "ExportInvoiceMaster",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_ShipModel_ShipModelId",
                table: "ExportInvoiceMaster",
                column: "ShipModelId",
                principalTable: "ShipModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_TradeTerm_TradeTermId",
                table: "ExportInvoiceMaster",
                column: "TradeTermId",
                principalTable: "TradeTerm",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_Destination_DestinationId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_ShipModel_ShipModelId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_TradeTerm_TradeTermId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoiceMaster_DestinationId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoiceMaster_ShipModelId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoiceMaster_TradeTermId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropColumn(
                name: "ShipModelId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropColumn(
                name: "TradeTermId",
                table: "ExportInvoiceMaster");
        }
    }
}
