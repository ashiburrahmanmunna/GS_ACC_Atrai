using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class salesreturn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseReturnId",
                table: "Acc_VoucherSub",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesReturnId",
                table: "Acc_VoucherSub",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_PurchaseReturnId",
                table: "Acc_VoucherSub",
                column: "PurchaseReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_SalesReturnId",
                table: "Acc_VoucherSub",
                column: "SalesReturnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSub_PurchaseReturn_PurchaseReturnId",
                table: "Acc_VoucherSub",
                column: "PurchaseReturnId",
                principalTable: "PurchaseReturn",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSub_SalesReturn_SalesReturnId",
                table: "Acc_VoucherSub",
                column: "SalesReturnId",
                principalTable: "SalesReturn",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSub_PurchaseReturn_PurchaseReturnId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSub_SalesReturn_SalesReturnId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSub_PurchaseReturnId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSub_SalesReturnId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropColumn(
                name: "PurchaseReturnId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropColumn(
                name: "SalesReturnId",
                table: "Acc_VoucherSub");
        }
    }
}
