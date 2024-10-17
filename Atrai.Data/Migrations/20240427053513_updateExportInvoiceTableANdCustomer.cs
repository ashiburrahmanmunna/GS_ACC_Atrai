using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateExportInvoiceTableANdCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShipModeId",
                table: "ExportInvoiceMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingMarks",
                table: "Customer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipModeId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropColumn(
                name: "ShippingMarks",
                table: "Customer");
        }
    }
}
