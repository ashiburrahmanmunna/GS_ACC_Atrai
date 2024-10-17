using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class transacctionmodelwithsalespurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_PurchaseId",
                table: "AccountsDailyTransaction",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_SalesId",
                table: "AccountsDailyTransaction",
                column: "SalesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_Purchase_PurchaseId",
                table: "AccountsDailyTransaction",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_Sales_SalesId",
                table: "AccountsDailyTransaction",
                column: "SalesId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_Purchase_PurchaseId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_Sales_SalesId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_PurchaseId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_SalesId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "SalesId",
                table: "AccountsDailyTransaction");
        }
    }
}
