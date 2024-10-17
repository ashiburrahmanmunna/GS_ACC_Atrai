using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class ExchangeBAtchSerial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExchangeDate",
                table: "PurchaseBatchItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ExchangeSerialNo",
                table: "PurchaseBatchItems",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "PurchaseBatchItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseBatchItems_SupplierId",
                table: "PurchaseBatchItems",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseBatchItems_Supplier_SupplierId",
                table: "PurchaseBatchItems",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseBatchItems_Supplier_SupplierId",
                table: "PurchaseBatchItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseBatchItems_SupplierId",
                table: "PurchaseBatchItems");

            migrationBuilder.DropColumn(
                name: "ExchangeDate",
                table: "PurchaseBatchItems");

            migrationBuilder.DropColumn(
                name: "ExchangeSerialNo",
                table: "PurchaseBatchItems");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "PurchaseBatchItems");
        }
    }
}
