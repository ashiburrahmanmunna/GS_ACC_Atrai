using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class AccountsTransctionPurchasereturnid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_PurchaseReturn_PurchaseReturnModelId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_SalesReturn_SalesReturnModelId",
                table: "AccountsDailyTransaction");

            migrationBuilder.RenameColumn(
                name: "SalesReturnModelId",
                table: "AccountsDailyTransaction",
                newName: "SalesReturnId");

            migrationBuilder.RenameColumn(
                name: "PurchaseReturnModelId",
                table: "AccountsDailyTransaction",
                newName: "PurchaseReturnId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsDailyTransaction_SalesReturnModelId",
                table: "AccountsDailyTransaction",
                newName: "IX_AccountsDailyTransaction_SalesReturnId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsDailyTransaction_PurchaseReturnModelId",
                table: "AccountsDailyTransaction",
                newName: "IX_AccountsDailyTransaction_PurchaseReturnId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_PurchaseReturn_PurchaseReturnId",
                table: "AccountsDailyTransaction",
                column: "PurchaseReturnId",
                principalTable: "PurchaseReturn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_SalesReturn_SalesReturnId",
                table: "AccountsDailyTransaction",
                column: "SalesReturnId",
                principalTable: "SalesReturn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_PurchaseReturn_PurchaseReturnId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_SalesReturn_SalesReturnId",
                table: "AccountsDailyTransaction");

            migrationBuilder.RenameColumn(
                name: "SalesReturnId",
                table: "AccountsDailyTransaction",
                newName: "SalesReturnModelId");

            migrationBuilder.RenameColumn(
                name: "PurchaseReturnId",
                table: "AccountsDailyTransaction",
                newName: "PurchaseReturnModelId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsDailyTransaction_SalesReturnId",
                table: "AccountsDailyTransaction",
                newName: "IX_AccountsDailyTransaction_SalesReturnModelId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsDailyTransaction_PurchaseReturnId",
                table: "AccountsDailyTransaction",
                newName: "IX_AccountsDailyTransaction_PurchaseReturnModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_PurchaseReturn_PurchaseReturnModelId",
                table: "AccountsDailyTransaction",
                column: "PurchaseReturnModelId",
                principalTable: "PurchaseReturn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_SalesReturn_SalesReturnModelId",
                table: "AccountsDailyTransaction",
                column: "SalesReturnModelId",
                principalTable: "SalesReturn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
