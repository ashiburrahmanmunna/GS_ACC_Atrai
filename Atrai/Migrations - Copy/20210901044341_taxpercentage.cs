using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class taxpercentage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TaxPer",
                table: "StoreSetting",
                type: "decimal(18,2)",
                maxLength: 50,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "isTaxExcluded",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxPer",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "isTaxExcluded",
                table: "StoreSetting");
        }
    }
}
