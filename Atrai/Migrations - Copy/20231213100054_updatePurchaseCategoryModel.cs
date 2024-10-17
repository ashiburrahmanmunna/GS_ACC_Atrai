using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class updatePurchaseCategoryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasterTaxId",
                table: "PurchaseItemsCategory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItemsCategory_MasterTaxId",
                table: "PurchaseItemsCategory",
                column: "MasterTaxId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItemsCategory_MasterSalesTax_MasterTaxId",
                table: "PurchaseItemsCategory",
                column: "MasterTaxId",
                principalTable: "MasterSalesTax",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItemsCategory_MasterSalesTax_MasterTaxId",
                table: "PurchaseItemsCategory");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItemsCategory_MasterTaxId",
                table: "PurchaseItemsCategory");

            migrationBuilder.DropColumn(
                name: "MasterTaxId",
                table: "PurchaseItemsCategory");
        }
    }
}
