using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class updateProductTaxtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaxId",
                table: "SalesProductTax",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TotalAmount",
                table: "SalesProductTax",
                type: "real",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesProductTax_TaxId",
                table: "SalesProductTax",
                column: "TaxId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesProductTax_SalesTax_TaxId",
                table: "SalesProductTax",
                column: "TaxId",
                principalTable: "SalesTax",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesProductTax_SalesTax_TaxId",
                table: "SalesProductTax");

            migrationBuilder.DropIndex(
                name: "IX_SalesProductTax_TaxId",
                table: "SalesProductTax");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "SalesProductTax");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "SalesProductTax");
        }
    }
}
