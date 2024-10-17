using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updatePurchaseProductTax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaxId",
                table: "PurchaseProductTax",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProductTax_TaxId",
                table: "PurchaseProductTax",
                column: "TaxId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProductTax_SalesTax_TaxId",
                table: "PurchaseProductTax",
                column: "TaxId",
                principalTable: "SalesTax",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProductTax_SalesTax_TaxId",
                table: "PurchaseProductTax");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseProductTax_TaxId",
                table: "PurchaseProductTax");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "PurchaseProductTax");
        }
    }
}
