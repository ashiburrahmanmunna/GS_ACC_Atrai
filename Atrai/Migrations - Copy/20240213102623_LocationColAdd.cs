using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class LocationColAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "AccountHead",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountHead_WarehouseId",
                table: "AccountHead",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHead_Warehouse_WarehouseId",
                table: "AccountHead",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountHead_Warehouse_WarehouseId",
                table: "AccountHead");

            migrationBuilder.DropIndex(
                name: "IX_AccountHead_WarehouseId",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "AccountHead");
        }
    }
}
