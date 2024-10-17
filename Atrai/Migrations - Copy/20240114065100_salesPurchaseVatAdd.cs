using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class salesPurchaseVatAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccIdPurchaseTaxes",
                table: "SalesTax",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccIdSalesTaxes",
                table: "SalesTax",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesTax_AccIdPurchaseTaxes",
                table: "SalesTax",
                column: "AccIdPurchaseTaxes");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTax_AccIdSalesTaxes",
                table: "SalesTax",
                column: "AccIdSalesTaxes");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesTax_AccountHead_AccIdPurchaseTaxes",
                table: "SalesTax",
                column: "AccIdPurchaseTaxes",
                principalTable: "AccountHead",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesTax_AccountHead_AccIdSalesTaxes",
                table: "SalesTax",
                column: "AccIdSalesTaxes",
                principalTable: "AccountHead",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesTax_AccountHead_AccIdPurchaseTaxes",
                table: "SalesTax");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesTax_AccountHead_AccIdSalesTaxes",
                table: "SalesTax");

            migrationBuilder.DropIndex(
                name: "IX_SalesTax_AccIdPurchaseTaxes",
                table: "SalesTax");

            migrationBuilder.DropIndex(
                name: "IX_SalesTax_AccIdSalesTaxes",
                table: "SalesTax");

            migrationBuilder.DropColumn(
                name: "AccIdPurchaseTaxes",
                table: "SalesTax");

            migrationBuilder.DropColumn(
                name: "AccIdSalesTaxes",
                table: "SalesTax");
        }
    }
}
