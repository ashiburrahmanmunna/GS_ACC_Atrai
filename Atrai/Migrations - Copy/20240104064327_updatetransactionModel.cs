using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updatetransactionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "RecurringDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRecurring",
                table: "AccountsDailyTransaction",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_RecurringDetails_TransactionId",
                table: "RecurringDetails",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecurringDetails_AccountsDailyTransaction_TransactionId",
                table: "RecurringDetails",
                column: "TransactionId",
                principalTable: "AccountsDailyTransaction",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecurringDetails_AccountsDailyTransaction_TransactionId",
                table: "RecurringDetails");

            migrationBuilder.DropIndex(
                name: "IX_RecurringDetails_TransactionId",
                table: "RecurringDetails");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "RecurringDetails");

            migrationBuilder.DropColumn(
                name: "IsRecurring",
                table: "AccountsDailyTransaction");
        }
    }
}
