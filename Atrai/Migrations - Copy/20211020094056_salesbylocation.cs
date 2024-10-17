using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class salesbylocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_WarehouseId",
                table: "Sales",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Warehouse_WarehouseId",
                table: "Sales",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Warehouse_WarehouseId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_WarehouseId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Sales");
        }
    }
}
