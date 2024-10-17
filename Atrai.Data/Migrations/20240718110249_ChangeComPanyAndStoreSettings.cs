using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeComPanyAndStoreSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Acc_VoucherNoCreatedType_VoucherNoCreatedTypeId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Country_CountryId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Country_CurrencyId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_CountryId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_CurrencyId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_VoucherNoCreatedTypeId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "IsSignature",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "VoucherNoCreatedTypeId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "isChequeDetails",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "isEmailSerivce",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "isMultiCurrency",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "isMultiDebitCredit",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "isSMSService",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "isVoucherDistributionEntry",
                table: "Company");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Company",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Company",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSignature",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "VoucherNoCreatedTypeId",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isChequeDetails",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isEmailSerivce",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isMultiCurrency",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isMultiDebitCredit",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isSMSService",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isVoucherDistributionEntry",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Company_CountryId",
                table: "Company",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CurrencyId",
                table: "Company",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_VoucherNoCreatedTypeId",
                table: "Company",
                column: "VoucherNoCreatedTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Acc_VoucherNoCreatedType_VoucherNoCreatedTypeId",
                table: "Company",
                column: "VoucherNoCreatedTypeId",
                principalTable: "Acc_VoucherNoCreatedType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Country_CountryId",
                table: "Company",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Country_CurrencyId",
                table: "Company",
                column: "CurrencyId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
