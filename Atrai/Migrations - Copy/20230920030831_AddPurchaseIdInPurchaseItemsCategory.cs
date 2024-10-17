using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class AddPurchaseIdInPurchaseItemsCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItemsCategory_Purchase_PurchaseModelId",
                table: "PurchaseItemsCategory");

            migrationBuilder.RenameColumn(
                name: "PurchaseModelId",
                table: "PurchaseItemsCategory",
                newName: "PurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseItemsCategory_PurchaseModelId",
                table: "PurchaseItemsCategory",
                newName: "IX_PurchaseItemsCategory_PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItemsCategory_Purchase_PurchaseId",
                table: "PurchaseItemsCategory",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItemsCategory_Purchase_PurchaseId",
                table: "PurchaseItemsCategory");

            migrationBuilder.RenameColumn(
                name: "PurchaseId",
                table: "PurchaseItemsCategory",
                newName: "PurchaseModelId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseItemsCategory_PurchaseId",
                table: "PurchaseItemsCategory",
                newName: "IX_PurchaseItemsCategory_PurchaseModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItemsCategory_Purchase_PurchaseModelId",
                table: "PurchaseItemsCategory",
                column: "PurchaseModelId",
                principalTable: "Purchase",
                principalColumn: "Id");
        }
    }
}
