using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class vatandait : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AIT",
                table: "AccountsDailyTransactionDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VAT",
                table: "AccountsDailyTransactionDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AITAmount",
                table: "AccountsDailyTransaction",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VATAmount",
                table: "AccountsDailyTransaction",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AIT",
                table: "AccountsDailyTransactionDetails");

            migrationBuilder.DropColumn(
                name: "VAT",
                table: "AccountsDailyTransactionDetails");

            migrationBuilder.DropColumn(
                name: "AITAmount",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "VATAmount",
                table: "AccountsDailyTransaction");
        }
    }
}
