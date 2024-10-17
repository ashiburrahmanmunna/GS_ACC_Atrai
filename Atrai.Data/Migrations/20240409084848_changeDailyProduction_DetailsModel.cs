using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeDailyProduction_DetailsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "DailyProduction_Details",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyProduction_Details_DepartmentId",
                table: "DailyProduction_Details",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyProduction_Details_Cat_Department_DepartmentId",
                table: "DailyProduction_Details",
                column: "DepartmentId",
                principalTable: "Cat_Department",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyProduction_Details_Cat_Department_DepartmentId",
                table: "DailyProduction_Details");

            migrationBuilder.DropIndex(
                name: "IX_DailyProduction_Details_DepartmentId",
                table: "DailyProduction_Details");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "DailyProduction_Details");
        }
    }
}
