using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class accountsvoucherwithsalespurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VoucherId",
                table: "SalesPayment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoucherId",
                table: "PurchasePayment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Acc_VoucherSub",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "Acc_VoucherSub",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesId",
                table: "Acc_VoucherSub",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesPayment_VoucherId",
                table: "SalesPayment",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayment_VoucherId",
                table: "PurchasePayment",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_MemberId",
                table: "Acc_VoucherSub",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_PurchaseId",
                table: "Acc_VoucherSub",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_SalesId",
                table: "Acc_VoucherSub",
                column: "SalesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSub_Member_MemberId",
                table: "Acc_VoucherSub",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSub_Purchase_PurchaseId",
                table: "Acc_VoucherSub",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSub_Sales_SalesId",
                table: "Acc_VoucherSub",
                column: "SalesId",
                principalTable: "Sales",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayment_Acc_VoucherMain_VoucherId",
                table: "PurchasePayment",
                column: "VoucherId",
                principalTable: "Acc_VoucherMain",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPayment_Acc_VoucherMain_VoucherId",
                table: "SalesPayment",
                column: "VoucherId",
                principalTable: "Acc_VoucherMain",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSub_Member_MemberId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSub_Purchase_PurchaseId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSub_Sales_SalesId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayment_Acc_VoucherMain_VoucherId",
                table: "PurchasePayment");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPayment_Acc_VoucherMain_VoucherId",
                table: "SalesPayment");

            migrationBuilder.DropIndex(
                name: "IX_SalesPayment_VoucherId",
                table: "SalesPayment");

            migrationBuilder.DropIndex(
                name: "IX_PurchasePayment_VoucherId",
                table: "PurchasePayment");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSub_MemberId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSub_PurchaseId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSub_SalesId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropColumn(
                name: "VoucherId",
                table: "SalesPayment");

            migrationBuilder.DropColumn(
                name: "VoucherId",
                table: "PurchasePayment");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropColumn(
                name: "SalesId",
                table: "Acc_VoucherSub");
        }
    }
}
