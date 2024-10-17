using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateTrxnApprovalStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "TransactionApprovalStatus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionApprovalStatus_TransactionId",
                table: "TransactionApprovalStatus",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionApprovalStatus_AccountsDailyTransaction_TransactionId",
                table: "TransactionApprovalStatus",
                column: "TransactionId",
                principalTable: "AccountsDailyTransaction",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionApprovalStatus_AccountsDailyTransaction_TransactionId",
                table: "TransactionApprovalStatus");

            migrationBuilder.DropIndex(
                name: "IX_TransactionApprovalStatus_TransactionId",
                table: "TransactionApprovalStatus");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "TransactionApprovalStatus");
        }
    }
}
