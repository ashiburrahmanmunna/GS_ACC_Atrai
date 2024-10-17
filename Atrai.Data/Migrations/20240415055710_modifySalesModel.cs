using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class modifySalesModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FiscalMonthId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_FiscalMonthId",
                table: "Sales",
                column: "FiscalMonthId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Acc_FiscalMonth_FiscalMonthId",
                table: "Sales",
                column: "FiscalMonthId",
                principalTable: "Acc_FiscalMonth",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Acc_FiscalMonth_FiscalMonthId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_FiscalMonthId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "FiscalMonthId",
                table: "Sales");
        }
    }
}
