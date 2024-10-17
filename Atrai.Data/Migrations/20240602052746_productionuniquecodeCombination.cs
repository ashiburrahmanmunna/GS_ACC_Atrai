using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class productionuniquecodeCombination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_ComId_Code_Name_ColorName_SizeName_UnitId_CategoryId_ModelName",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ComId_Code_ColorName_SizeName_ModelName",
                table: "Product",
                columns: new[] { "ComId", "Code", "ColorName", "SizeName", "ModelName" },
                unique: true,
                filter: "[ColorName] IS NOT NULL AND [SizeName] IS NOT NULL AND [ModelName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_ComId_Code_ColorName_SizeName_ModelName",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ComId_Code_Name_ColorName_SizeName_UnitId_CategoryId_ModelName",
                table: "Product",
                columns: new[] { "ComId", "Code", "Name", "ColorName", "SizeName", "UnitId", "CategoryId", "ModelName" },
                unique: true,
                filter: "[ColorName] IS NOT NULL AND [SizeName] IS NOT NULL AND [ModelName] IS NOT NULL");
        }
    }
}
