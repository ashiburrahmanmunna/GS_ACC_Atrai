using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class modifyExportPackingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartoonFrom",
                table: "ExportInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "CartoonTo",
                table: "ExportInvoiceDetails");

            migrationBuilder.AddColumn<int>(
                name: "CartonFrom",
                table: "ExportInvoicePackingList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartonTo",
                table: "ExportInvoicePackingList",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartonFrom",
                table: "ExportInvoicePackingList");

            migrationBuilder.DropColumn(
                name: "CartonTo",
                table: "ExportInvoicePackingList");

            migrationBuilder.AddColumn<int>(
                name: "CartoonFrom",
                table: "ExportInvoiceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartoonTo",
                table: "ExportInvoiceDetails",
                type: "int",
                nullable: true);
        }
    }
}
