using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class modifyPurchaseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FiscalMonthId",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_FiscalMonthId",
                table: "Purchase",
                column: "FiscalMonthId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Acc_FiscalMonth_FiscalMonthId",
                table: "Purchase",
                column: "FiscalMonthId",
                principalTable: "Acc_FiscalMonth",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Acc_FiscalMonth_FiscalMonthId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_FiscalMonthId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "FiscalMonthId",
                table: "Purchase");
        }
    }
}
