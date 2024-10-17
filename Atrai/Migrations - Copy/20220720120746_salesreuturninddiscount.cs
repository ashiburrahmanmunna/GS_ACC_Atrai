using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class salesreuturninddiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "IndDisPer",
                table: "SalesReturnItems",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IndDiscount",
                table: "SalesReturnItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndDisPer",
                table: "SalesReturnItems");

            migrationBuilder.DropColumn(
                name: "IndDiscount",
                table: "SalesReturnItems");
        }
    }
}
