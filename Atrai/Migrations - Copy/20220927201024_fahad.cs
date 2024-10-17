using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class fahad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_WarehouseId",
                table: "AccountsDailyTransaction",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_Warehouse_WarehouseId",
                table: "AccountsDailyTransaction",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_Warehouse_WarehouseId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_WarehouseId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "AccountsDailyTransaction");
        }
    }
}
