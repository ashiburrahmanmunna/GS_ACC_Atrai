using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class updatePurchaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasterTaxId",
                table: "PurchaseItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AmountsAre",
                table: "Purchase",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_MasterTaxId",
                table: "PurchaseItems",
                column: "MasterTaxId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_MasterSalesTax_MasterTaxId",
                table: "PurchaseItems",
                column: "MasterTaxId",
                principalTable: "MasterSalesTax",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_MasterSalesTax_MasterTaxId",
                table: "PurchaseItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItems_MasterTaxId",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "MasterTaxId",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "AmountsAre",
                table: "Purchase");
        }
    }
}
