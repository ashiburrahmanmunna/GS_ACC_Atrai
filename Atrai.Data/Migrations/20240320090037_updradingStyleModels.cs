using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class updradingStyleModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BOMQuantitySizeWise_BOMDetailsId",
                table: "BOMQuantitySizeWise");

            migrationBuilder.CreateIndex(
                name: "IX_BOMQuantitySizeWise_BOMDetailsId",
                table: "BOMQuantitySizeWise",
                column: "BOMDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BOMQuantitySizeWise_BOMDetailsId",
                table: "BOMQuantitySizeWise");

            migrationBuilder.CreateIndex(
                name: "IX_BOMQuantitySizeWise_BOMDetailsId",
                table: "BOMQuantitySizeWise",
                column: "BOMDetailsId",
                unique: true);
        }
    }
}
