using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updatepurchaseitemsmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "PurchaseItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "PurchaseItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StyleId",
                table: "PurchaseItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_ColorId",
                table: "PurchaseItems",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_SizeId",
                table: "PurchaseItems",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_StyleId",
                table: "PurchaseItems",
                column: "StyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_Colors_ColorId",
                table: "PurchaseItems",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_Sizes_SizeId",
                table: "PurchaseItems",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_Style_StyleId",
                table: "PurchaseItems",
                column: "StyleId",
                principalTable: "Style",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_Colors_ColorId",
                table: "PurchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_Sizes_SizeId",
                table: "PurchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_Style_StyleId",
                table: "PurchaseItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItems_ColorId",
                table: "PurchaseItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItems_SizeId",
                table: "PurchaseItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItems_StyleId",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "StyleId",
                table: "PurchaseItems");
        }
    }
}
