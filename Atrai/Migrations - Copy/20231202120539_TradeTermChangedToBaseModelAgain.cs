using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class TradeTermChangedToBaseModelAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_TradeTerms_TermsId",
                table: "StoreSetting");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_PaymentTerms_TermsId",
                table: "StoreSetting",
                column: "TermsId",
                principalTable: "PaymentTerms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_PaymentTerms_TermsId",
                table: "StoreSetting");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_TradeTerms_TermsId",
                table: "StoreSetting",
                column: "TermsId",
                principalTable: "TradeTerms",
                principalColumn: "Id");
        }
    }
}
