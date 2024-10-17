using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class transactiontablelink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "SalesPayment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "PurchasePayment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesPayment_TransactionId",
                table: "SalesPayment",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayment_TransactionId",
                table: "PurchasePayment",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayment_AccountsDailyTransaction_TransactionId",
                table: "PurchasePayment",
                column: "TransactionId",
                principalTable: "AccountsDailyTransaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPayment_AccountsDailyTransaction_TransactionId",
                table: "SalesPayment",
                column: "TransactionId",
                principalTable: "AccountsDailyTransaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayment_AccountsDailyTransaction_TransactionId",
                table: "PurchasePayment");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPayment_AccountsDailyTransaction_TransactionId",
                table: "SalesPayment");

            migrationBuilder.DropIndex(
                name: "IX_SalesPayment_TransactionId",
                table: "SalesPayment");

            migrationBuilder.DropIndex(
                name: "IX_PurchasePayment_TransactionId",
                table: "PurchasePayment");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "SalesPayment");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "PurchasePayment");
        }
    }
}
