using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class addInDeptWiseDailyProductionDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentBuyerPOId",
                table: "DeptWise_DailyProduction_Details",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeptWise_DailyProduction_Details_ParentBuyerPOId",
                table: "DeptWise_DailyProduction_Details",
                column: "ParentBuyerPOId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeptWise_DailyProduction_Details_BuyerPO_Master_ParentBuyerPOId",
                table: "DeptWise_DailyProduction_Details",
                column: "ParentBuyerPOId",
                principalTable: "BuyerPO_Master",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeptWise_DailyProduction_Details_BuyerPO_Master_ParentBuyerPOId",
                table: "DeptWise_DailyProduction_Details");

            migrationBuilder.DropIndex(
                name: "IX_DeptWise_DailyProduction_Details_ParentBuyerPOId",
                table: "DeptWise_DailyProduction_Details");

            migrationBuilder.DropColumn(
                name: "ParentBuyerPOId",
                table: "DeptWise_DailyProduction_Details");
        }
    }
}
