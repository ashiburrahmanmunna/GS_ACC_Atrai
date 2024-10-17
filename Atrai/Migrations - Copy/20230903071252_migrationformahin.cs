using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class migrationformahin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PurchaseItemsCategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "PurchaseBatchItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PurchaseBatchItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "QTY",
                table: "PurchaseBatchItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "PurchaseBatchItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "PurchaseBatchItems",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PurchaseItemsCategory");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "PurchaseBatchItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PurchaseBatchItems");

            migrationBuilder.DropColumn(
                name: "QTY",
                table: "PurchaseBatchItems");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "PurchaseBatchItems");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "PurchaseBatchItems");
        }
    }
}
