using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class salesModelExyedned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "salesRecievedtTermsId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_salesRecievedtTermsId",
                table: "Sales",
                column: "salesRecievedtTermsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_PaymentTerms_salesRecievedtTermsId",
                table: "Sales",
                column: "salesRecievedtTermsId",
                principalTable: "PaymentTerms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_PaymentTerms_salesRecievedtTermsId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_salesRecievedtTermsId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "salesRecievedtTermsId",
                table: "Sales");
        }
    }
}
