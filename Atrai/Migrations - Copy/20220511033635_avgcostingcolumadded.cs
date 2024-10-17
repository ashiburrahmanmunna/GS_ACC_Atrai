using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class avgcostingcolumadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AvgCostPrice",
                table: "SalesReturnItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AvgCostPrice",
                table: "SalesExchangeItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AvgCostPrice",
                table: "InternalTransferItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgCostPrice",
                table: "SalesReturnItems");

            migrationBuilder.DropColumn(
                name: "AvgCostPrice",
                table: "SalesExchangeItems");

            migrationBuilder.DropColumn(
                name: "AvgCostPrice",
                table: "InternalTransferItems");
        }
    }
}
