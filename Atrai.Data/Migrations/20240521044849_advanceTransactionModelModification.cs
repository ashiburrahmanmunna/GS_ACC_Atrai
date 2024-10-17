using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class advanceTransactionModelModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpenseHeadId",
                table: "AdvanceTrasactionTracking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceTrasactionTracking_ExpenseHeadId",
                table: "AdvanceTrasactionTracking",
                column: "ExpenseHeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvanceTrasactionTracking_AccountHead_ExpenseHeadId",
                table: "AdvanceTrasactionTracking",
                column: "ExpenseHeadId",
                principalTable: "AccountHead",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvanceTrasactionTracking_AccountHead_ExpenseHeadId",
                table: "AdvanceTrasactionTracking");

            migrationBuilder.DropIndex(
                name: "IX_AdvanceTrasactionTracking_ExpenseHeadId",
                table: "AdvanceTrasactionTracking");

            migrationBuilder.DropColumn(
                name: "ExpenseHeadId",
                table: "AdvanceTrasactionTracking");
        }
    }
}
