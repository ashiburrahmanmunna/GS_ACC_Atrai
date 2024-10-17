using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class Purchaseitemsprofitper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ProfitPer",
                table: "PurchaseItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SalesUnitPrice",
                table: "PurchaseItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfitPer",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "SalesUnitPrice",
                table: "PurchaseItems");
        }
    }
}
