using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class GSMCustomerCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyRate",
                table: "Purchase",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GSM",
                table: "Product",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CurrencyId",
                table: "Purchase",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CustomerId",
                table: "Purchase",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Country_CurrencyId",
                table: "Purchase",
                column: "CurrencyId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Customer_CustomerId",
                table: "Purchase",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Country_CurrencyId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Customer_CustomerId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_CurrencyId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_CustomerId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "CurrencyRate",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "GSM",
                table: "Product");
        }
    }
}
