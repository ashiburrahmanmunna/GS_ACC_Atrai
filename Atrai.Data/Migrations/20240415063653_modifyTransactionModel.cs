using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class modifyTransactionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FiscalMonthId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_FiscalMonthId",
                table: "AccountsDailyTransaction",
                column: "FiscalMonthId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_Acc_FiscalMonth_FiscalMonthId",
                table: "AccountsDailyTransaction",
                column: "FiscalMonthId",
                principalTable: "Acc_FiscalMonth",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_Acc_FiscalMonth_FiscalMonthId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_FiscalMonthId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "FiscalMonthId",
                table: "AccountsDailyTransaction");
        }
    }
}
