using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class unitoknow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Unit_vUnitId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_vUnitId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "vUnitId",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UnitId",
                table: "Product",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unit_UnitId",
                table: "Product",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Unit_UnitId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UnitId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "vUnitId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_vUnitId",
                table: "Product",
                column: "vUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unit_vUnitId",
                table: "Product",
                column: "vUnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
