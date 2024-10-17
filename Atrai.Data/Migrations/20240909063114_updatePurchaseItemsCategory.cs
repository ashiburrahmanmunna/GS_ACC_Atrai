using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatePurchaseItemsCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TDS",
                table: "PurchaseItemsCategory",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VAT",
                table: "PurchaseItemsCategory",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VDS",
                table: "PurchaseItemsCategory",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TDS",
                table: "PurchaseItemsCategory");

            migrationBuilder.DropColumn(
                name: "VAT",
                table: "PurchaseItemsCategory");

            migrationBuilder.DropColumn(
                name: "VDS",
                table: "PurchaseItemsCategory");
        }
    }
}
