using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class wholesalesfacility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Warehouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isWholeSales",
                table: "Sales",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "PCTN",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WholeSalePrice",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "isWholeSales",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "PCTN",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "WholeSalePrice",
                table: "Product");
        }
    }
}
