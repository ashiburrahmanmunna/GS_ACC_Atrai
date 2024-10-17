using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class ProductModelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentProductId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "Product",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isSystem",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ColorId",
                table: "Product",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ParentProductId",
                table: "Product",
                column: "ParentProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SizeId",
                table: "Product",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Color_ColorId",
                table: "Product",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Product_ParentProductId",
                table: "Product",
                column: "ParentProductId",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Size_SizeId",
                table: "Product",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Color_ColorId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Product_ParentProductId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Size_SizeId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ColorId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ParentProductId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_SizeId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ParentProductId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "isSystem",
                table: "Product");
        }
    }
}
