using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updateDailyProductionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerPOId",
                table: "DailyProduction_Master",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyProduction_Master_BuyerPOId",
                table: "DailyProduction_Master",
                column: "BuyerPOId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyProduction_Master_BuyerPO_Master_BuyerPOId",
                table: "DailyProduction_Master",
                column: "BuyerPOId",
                principalTable: "BuyerPO_Master",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyProduction_Master_BuyerPO_Master_BuyerPOId",
                table: "DailyProduction_Master");

            migrationBuilder.DropIndex(
                name: "IX_DailyProduction_Master_BuyerPOId",
                table: "DailyProduction_Master");

            migrationBuilder.DropColumn(
                name: "BuyerPOId",
                table: "DailyProduction_Master");
        }
    }
}
