using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class PurchaseItemsCategoryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseItemsCategoryId",
                table: "PurchaseItemsCategory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItemsCategory_PurchaseItemsCategoryId",
                table: "PurchaseItemsCategory",
                column: "PurchaseItemsCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItemsCategory_PurchaseItemsCategory_PurchaseItemsCategoryId",
                table: "PurchaseItemsCategory",
                column: "PurchaseItemsCategoryId",
                principalTable: "PurchaseItemsCategory",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItemsCategory_PurchaseItemsCategory_PurchaseItemsCategoryId",
                table: "PurchaseItemsCategory");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItemsCategory_PurchaseItemsCategoryId",
                table: "PurchaseItemsCategory");

            migrationBuilder.DropColumn(
                name: "PurchaseItemsCategoryId",
                table: "PurchaseItemsCategory");
        }
    }
}
