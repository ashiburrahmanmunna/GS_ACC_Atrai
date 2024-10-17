using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class individualdiscountexchangeitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "IndDisPer",
                table: "SalesExchangeItems",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IndDiscount",
                table: "SalesExchangeItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndDisPer",
                table: "SalesExchangeItems");

            migrationBuilder.DropColumn(
                name: "IndDiscount",
                table: "SalesExchangeItems");
        }
    }
}
