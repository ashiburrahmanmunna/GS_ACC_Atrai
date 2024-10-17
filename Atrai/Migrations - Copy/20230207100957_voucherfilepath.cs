using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class voucherfilepath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherTags_Acc_VoucherSub_Acc_VoucherSubModelId",
                table: "Acc_VoucherTags");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherTags_Acc_VoucherSubModelId",
                table: "Acc_VoucherTags");

            migrationBuilder.DropColumn(
                name: "Acc_VoucherSubModelId",
                table: "Acc_VoucherTags");

            migrationBuilder.AddColumn<string>(
                name: "VoucherFilePath",
                table: "Acc_VoucherMain",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoucherFilePath",
                table: "Acc_VoucherMain");

            migrationBuilder.AddColumn<int>(
                name: "Acc_VoucherSubModelId",
                table: "Acc_VoucherTags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherTags_Acc_VoucherSubModelId",
                table: "Acc_VoucherTags",
                column: "Acc_VoucherSubModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherTags_Acc_VoucherSub_Acc_VoucherSubModelId",
                table: "Acc_VoucherTags",
                column: "Acc_VoucherSubModelId",
                principalTable: "Acc_VoucherSub",
                principalColumn: "Id");
        }
    }
}
