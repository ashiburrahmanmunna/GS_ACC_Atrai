using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class accidsalesvatandpurchasevat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccIdPurchaseVAT",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccIdSalesVAT",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_AccIdPurchaseVAT",
                table: "Product",
                column: "AccIdPurchaseVAT");

            migrationBuilder.CreateIndex(
                name: "IX_Product_AccIdSalesVAT",
                table: "Product",
                column: "AccIdSalesVAT");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AccountHead_AccIdPurchaseVAT",
                table: "Product",
                column: "AccIdPurchaseVAT",
                principalTable: "AccountHead",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AccountHead_AccIdSalesVAT",
                table: "Product",
                column: "AccIdSalesVAT",
                principalTable: "AccountHead",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_AccountHead_AccIdPurchaseVAT",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_AccountHead_AccIdSalesVAT",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_AccIdPurchaseVAT",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_AccIdSalesVAT",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AccIdPurchaseVAT",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AccIdSalesVAT",
                table: "Product");
        }
    }
}
