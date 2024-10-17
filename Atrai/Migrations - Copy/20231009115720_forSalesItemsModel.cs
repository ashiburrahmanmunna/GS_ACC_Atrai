using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class forSalesItemsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesItems_TokenSales_TokenSalesModelId",
                table: "SalesItems");

            migrationBuilder.RenameColumn(
                name: "TokenSalesModelId",
                table: "SalesItems",
                newName: "TokenItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesItems_TokenSalesModelId",
                table: "SalesItems",
                newName: "IX_SalesItems_TokenItemsId");

            migrationBuilder.AddColumn<decimal>(
                name: "ForwardSalesQuantity",
                table: "SalesItems",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IssueQuantity",
                table: "SalesItems",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseItemsId",
                table: "SalesItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ReturnQuantity",
                table: "SalesItems",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TokenSalesQty",
                table: "SalesItems",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_PurchaseItemsId",
                table: "SalesItems",
                column: "PurchaseItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesItems_PurchaseItems_PurchaseItemsId",
                table: "SalesItems",
                column: "PurchaseItemsId",
                principalTable: "PurchaseItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesItems_TokenSales_TokenItemsId",
                table: "SalesItems",
                column: "TokenItemsId",
                principalTable: "TokenSales",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesItems_PurchaseItems_PurchaseItemsId",
                table: "SalesItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesItems_TokenSales_TokenItemsId",
                table: "SalesItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesItems_PurchaseItemsId",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "ForwardSalesQuantity",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "IssueQuantity",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "PurchaseItemsId",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "ReturnQuantity",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "TokenSalesQty",
                table: "SalesItems");

            migrationBuilder.RenameColumn(
                name: "TokenItemsId",
                table: "SalesItems",
                newName: "TokenSalesModelId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesItems_TokenItemsId",
                table: "SalesItems",
                newName: "IX_SalesItems_TokenSalesModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesItems_TokenSales_TokenSalesModelId",
                table: "SalesItems",
                column: "TokenSalesModelId",
                principalTable: "TokenSales",
                principalColumn: "Id");
        }
    }
}
