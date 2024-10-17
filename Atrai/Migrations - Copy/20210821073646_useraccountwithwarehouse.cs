using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class useraccountwithwarehouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "UserAccount",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_WarehouseId",
                table: "UserAccount",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_Warehouse_WarehouseId",
                table: "UserAccount",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_Warehouse_WarehouseId",
                table: "UserAccount");

            migrationBuilder.DropIndex(
                name: "IX_UserAccount_WarehouseId",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "UserAccount");
        }
    }
}
