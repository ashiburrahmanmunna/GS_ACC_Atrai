using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class Vouchersubreferancecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DamageId",
                table: "Acc_VoucherSub",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IssueId",
                table: "Acc_VoucherSub",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransferInId",
                table: "Acc_VoucherSub",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransferOutId",
                table: "Acc_VoucherSub",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_DamageId",
                table: "Acc_VoucherSub",
                column: "DamageId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_IssueId",
                table: "Acc_VoucherSub",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_TransferInId",
                table: "Acc_VoucherSub",
                column: "TransferInId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_TransferOutId",
                table: "Acc_VoucherSub",
                column: "TransferOutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSub_Damage_DamageId",
                table: "Acc_VoucherSub",
                column: "DamageId",
                principalTable: "Damage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSub_InternalTransfer_TransferInId",
                table: "Acc_VoucherSub",
                column: "TransferInId",
                principalTable: "InternalTransfer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSub_InternalTransfer_TransferOutId",
                table: "Acc_VoucherSub",
                column: "TransferOutId",
                principalTable: "InternalTransfer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSub_Issue_IssueId",
                table: "Acc_VoucherSub",
                column: "IssueId",
                principalTable: "Issue",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSub_Damage_DamageId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSub_InternalTransfer_TransferInId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSub_InternalTransfer_TransferOutId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSub_Issue_IssueId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSub_DamageId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSub_IssueId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSub_TransferInId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSub_TransferOutId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropColumn(
                name: "DamageId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropColumn(
                name: "IssueId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropColumn(
                name: "TransferInId",
                table: "Acc_VoucherSub");

            migrationBuilder.DropColumn(
                name: "TransferOutId",
                table: "Acc_VoucherSub");
        }
    }
}
