using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class budgetSubModelExtended : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_BudgetSub_Acc_BudgetMain_Acc_BudgetMainModelId",
                table: "Acc_BudgetSub");

            migrationBuilder.RenameColumn(
                name: "Acc_BudgetMainModelId",
                table: "Acc_BudgetSub",
                newName: "BudgetId");

            migrationBuilder.RenameIndex(
                name: "IX_Acc_BudgetSub_Acc_BudgetMainModelId",
                table: "Acc_BudgetSub",
                newName: "IX_Acc_BudgetSub_BudgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_BudgetSub_Acc_BudgetMain_BudgetId",
                table: "Acc_BudgetSub",
                column: "BudgetId",
                principalTable: "Acc_BudgetMain",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_BudgetSub_Acc_BudgetMain_BudgetId",
                table: "Acc_BudgetSub");

            migrationBuilder.RenameColumn(
                name: "BudgetId",
                table: "Acc_BudgetSub",
                newName: "Acc_BudgetMainModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Acc_BudgetSub_BudgetId",
                table: "Acc_BudgetSub",
                newName: "IX_Acc_BudgetSub_Acc_BudgetMainModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_BudgetSub_Acc_BudgetMain_Acc_BudgetMainModelId",
                table: "Acc_BudgetSub",
                column: "Acc_BudgetMainModelId",
                principalTable: "Acc_BudgetMain",
                principalColumn: "Id");
        }
    }
}
