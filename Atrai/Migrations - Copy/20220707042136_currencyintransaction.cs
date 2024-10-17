using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class currencyintransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CurrencyRate",
                table: "Sales",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyRate",
                table: "AccountsDailyTransaction",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_CurrencyId",
                table: "AccountsDailyTransaction",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_Country_CurrencyId",
                table: "AccountsDailyTransaction",
                column: "CurrencyId",
                principalTable: "Country",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_Country_CurrencyId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_CurrencyId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "CurrencyRate",
                table: "AccountsDailyTransaction");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrencyRate",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");
        }
    }
}
