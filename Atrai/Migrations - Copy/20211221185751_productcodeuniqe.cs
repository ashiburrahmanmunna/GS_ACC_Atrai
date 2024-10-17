using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class productcodeuniqe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_ComId",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ComId_Code",
                table: "Product",
                columns: new[] { "ComId", "Code" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_ComId_Code",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ComId",
                table: "Product",
                column: "ComId");
        }
    }
}
