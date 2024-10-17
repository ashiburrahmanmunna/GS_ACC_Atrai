using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class rolroqmoq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MOQ",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ROL",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ROQ",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MOQ",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ROL",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ROQ",
                table: "Product");
        }
    }
}
