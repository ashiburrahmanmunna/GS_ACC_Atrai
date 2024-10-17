using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class tradeTermModelAddedInStoreSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_PurchaseTerms_TermsId",
                table: "StoreSetting");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_TradeTerms_TermsId",
                table: "StoreSetting",
                column: "TermsId",
                principalTable: "TradeTerms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_TradeTerms_TermsId",
                table: "StoreSetting");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_PurchaseTerms_TermsId",
                table: "StoreSetting",
                column: "TermsId",
                principalTable: "PurchaseTerms",
                principalColumn: "Id");
        }
    }
}
