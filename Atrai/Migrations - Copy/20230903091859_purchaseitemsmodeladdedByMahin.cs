using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class purchaseitemsmodeladdedByMahin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PurchaseItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "PurchaseItems",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AddColumn<string>(
                name: "BatchStartFrom",
                table: "PurchaseItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "QTY",
                table: "PurchaseItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "PurchaseItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "PurchaseItems",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchStartFrom",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "QTY",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "PurchaseItems");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PurchaseItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "PurchaseItems",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

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
    }
}
