using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class SalesTaxColumnAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccIdExpenseTax",
                table: "SalesTax",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesTax_AccIdExpenseTax",
                table: "SalesTax",
                column: "AccIdExpenseTax");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesTax_AccountHead_AccIdExpenseTax",
                table: "SalesTax",
                column: "AccIdExpenseTax",
                principalTable: "AccountHead",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesTax_AccountHead_AccIdExpenseTax",
                table: "SalesTax");

            migrationBuilder.DropIndex(
                name: "IX_SalesTax_AccIdExpenseTax",
                table: "SalesTax");

            migrationBuilder.DropColumn(
                name: "AccIdExpenseTax",
                table: "SalesTax");
        }
    }
}
