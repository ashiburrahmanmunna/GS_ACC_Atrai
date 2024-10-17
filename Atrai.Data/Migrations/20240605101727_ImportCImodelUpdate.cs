using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImportCImodelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportCI_Master_TradeTerms_TradeTermId",
                table: "ImportCI_Master");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportCI_Master_CommercialTradeTerm_TradeTermId",
                table: "ImportCI_Master",
                column: "TradeTermId",
                principalTable: "CommercialTradeTerm",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportCI_Master_CommercialTradeTerm_TradeTermId",
                table: "ImportCI_Master");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportCI_Master_TradeTerms_TradeTermId",
                table: "ImportCI_Master",
                column: "TradeTermId",
                principalTable: "TradeTerms",
                principalColumn: "Id");
        }
    }
}
