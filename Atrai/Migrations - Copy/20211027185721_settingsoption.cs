using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class settingsoption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VoucherNoCreatedTypeId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isChequeDetails",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isMultiCurrency",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isMultiDebitCredit",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isVoucherDistributionEntry",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_VoucherNoCreatedTypeId",
                table: "StoreSetting",
                column: "VoucherNoCreatedTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_Acc_VoucherNoCreatedType_VoucherNoCreatedTypeId",
                table: "StoreSetting",
                column: "VoucherNoCreatedTypeId",
                principalTable: "Acc_VoucherNoCreatedType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_Acc_VoucherNoCreatedType_VoucherNoCreatedTypeId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_VoucherNoCreatedTypeId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "VoucherNoCreatedTypeId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "isChequeDetails",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "isMultiCurrency",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "isMultiDebitCredit",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "isVoucherDistributionEntry",
                table: "StoreSetting");
        }
    }
}
