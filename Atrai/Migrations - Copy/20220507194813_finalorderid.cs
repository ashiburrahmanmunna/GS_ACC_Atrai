using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class finalorderid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_OrderId",
                table: "Sales",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Orders_OrderId",
                table: "Sales",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Orders_OrderId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_OrderId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Sales");
        }
    }
}
