using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class somechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "SalesReturnPayment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoucherId",
                table: "SalesReturnPayment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "PurchaseReturnPayment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoucherId",
                table: "PurchaseReturnPayment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnPayment_TransactionId",
                table: "SalesReturnPayment",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnPayment_VoucherId",
                table: "SalesReturnPayment",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnPayment_TransactionId",
                table: "PurchaseReturnPayment",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnPayment_VoucherId",
                table: "PurchaseReturnPayment",
                column: "VoucherId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnPayment_Acc_VoucherMain_VoucherId",
                table: "PurchaseReturnPayment",
                column: "VoucherId",
                principalTable: "Acc_VoucherMain",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnPayment_AccountsDailyTransaction_TransactionId",
                table: "PurchaseReturnPayment",
                column: "TransactionId",
                principalTable: "AccountsDailyTransaction",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturnPayment_Acc_VoucherMain_VoucherId",
                table: "SalesReturnPayment",
                column: "VoucherId",
                principalTable: "Acc_VoucherMain",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturnPayment_AccountsDailyTransaction_TransactionId",
                table: "SalesReturnPayment",
                column: "TransactionId",
                principalTable: "AccountsDailyTransaction",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnPayment_Acc_VoucherMain_VoucherId",
                table: "PurchaseReturnPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnPayment_AccountsDailyTransaction_TransactionId",
                table: "PurchaseReturnPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturnPayment_Acc_VoucherMain_VoucherId",
                table: "SalesReturnPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturnPayment_AccountsDailyTransaction_TransactionId",
                table: "SalesReturnPayment");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturnPayment_TransactionId",
                table: "SalesReturnPayment");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturnPayment_VoucherId",
                table: "SalesReturnPayment");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturnPayment_TransactionId",
                table: "PurchaseReturnPayment");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturnPayment_VoucherId",
                table: "PurchaseReturnPayment");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "SalesReturnPayment");

            migrationBuilder.DropColumn(
                name: "VoucherId",
                table: "SalesReturnPayment");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "PurchaseReturnPayment");

            migrationBuilder.DropColumn(
                name: "VoucherId",
                table: "PurchaseReturnPayment");
        }
    }
}
