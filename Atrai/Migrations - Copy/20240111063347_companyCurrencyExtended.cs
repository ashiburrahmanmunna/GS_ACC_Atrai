using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class companyCurrencyExtended : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyName",
                table: "CompanyCurrencies");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "CompanyCurrencies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCurrencies_CurrencyId",
                table: "CompanyCurrencies",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCurrencies_Country_CurrencyId",
                table: "CompanyCurrencies",
                column: "CurrencyId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCurrencies_Country_CurrencyId",
                table: "CompanyCurrencies");

            migrationBuilder.DropIndex(
                name: "IX_CompanyCurrencies_CurrencyId",
                table: "CompanyCurrencies");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "CompanyCurrencies");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyName",
                table: "CompanyCurrencies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
