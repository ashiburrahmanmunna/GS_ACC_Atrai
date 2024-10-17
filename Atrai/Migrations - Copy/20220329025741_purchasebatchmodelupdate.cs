using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class purchasebatchmodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "PurchaseBatchItems",
                newName: "PurchaseBatchQuantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "PurchaseBatchItems",
                newName: "PurchaseBatchPrice");

            migrationBuilder.AddColumn<double>(
                name: "SalesBatchAmount",
                table: "SalesBatchItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "SalesBatchQuantity",
                table: "SalesBatchItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "PurchaseBatchAmount",
                table: "PurchaseBatchItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesBatchAmount",
                table: "SalesBatchItems");

            migrationBuilder.DropColumn(
                name: "SalesBatchQuantity",
                table: "SalesBatchItems");

            migrationBuilder.DropColumn(
                name: "PurchaseBatchAmount",
                table: "PurchaseBatchItems");

            migrationBuilder.RenameColumn(
                name: "PurchaseBatchQuantity",
                table: "PurchaseBatchItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "PurchaseBatchPrice",
                table: "PurchaseBatchItems",
                newName: "Price");
        }
    }
}
