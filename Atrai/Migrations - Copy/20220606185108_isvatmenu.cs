using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class isvatmenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVatMenu",
                table: "Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubCheckno_VoucherId",
                table: "Acc_VoucherSubCheckno",
                column: "VoucherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubCheckno_Acc_VoucherMain_VoucherId",
                table: "Acc_VoucherSubCheckno",
                column: "VoucherId",
                principalTable: "Acc_VoucherMain",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubCheckno_Acc_VoucherMain_VoucherId",
                table: "Acc_VoucherSubCheckno");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSubCheckno_VoucherId",
                table: "Acc_VoucherSubCheckno");

            migrationBuilder.DropColumn(
                name: "IsVatMenu",
                table: "Menu");
        }
    }
}
