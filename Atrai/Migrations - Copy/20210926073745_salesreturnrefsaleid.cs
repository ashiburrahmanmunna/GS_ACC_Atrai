using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class salesreturnrefsaleid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "SalesReturn",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_SaleId",
                table: "SalesReturn",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturn_Sales_SaleId",
                table: "SalesReturn",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturn_Sales_SaleId",
                table: "SalesReturn");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturn_SaleId",
                table: "SalesReturn");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "SalesReturn");
        }
    }
}
