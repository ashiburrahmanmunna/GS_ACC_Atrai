using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class voucherid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VoucherId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_VoucherId",
                table: "AccountsDailyTransaction",
                column: "VoucherId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_Acc_VoucherMain_VoucherId",
                table: "AccountsDailyTransaction",
                column: "VoucherId",
                principalTable: "Acc_VoucherMain",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_Acc_VoucherMain_VoucherId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_VoucherId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "VoucherId",
                table: "AccountsDailyTransaction");
        }
    }
}
