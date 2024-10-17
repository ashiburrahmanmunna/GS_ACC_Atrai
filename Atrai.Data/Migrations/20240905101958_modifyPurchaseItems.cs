using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class modifyPurchaseItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaxAmount",
                table: "PurchaseItems",
                newName: "VAT");

            migrationBuilder.AddColumn<double>(
                name: "VDS",
                table: "PurchaseItems",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VDS",
                table: "PurchaseItems");

            migrationBuilder.RenameColumn(
                name: "VAT",
                table: "PurchaseItems",
                newName: "TaxAmount");
        }
    }
}
