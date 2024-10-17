using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class advancedTabColumnsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountingMethodId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DateFormatId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinancialYearId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAutoAppliedBillPayment",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAutoInvoicedUnbilled",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCloseTheBooks",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDuplicateBillNo",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDuplicateCheque",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDuplicateJournal",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabledAccNumbers",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOrganisedJob",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPreFillFormsPrevEnteredContent",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrackedClasses",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrackedLocations",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberFormatId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SignOutDurationId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaxRateId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fixMonthofTaxYear",
                table: "StoreSetting",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_AccountingMethodId",
                table: "StoreSetting",
                column: "AccountingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_DateFormatId",
                table: "StoreSetting",
                column: "DateFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_FinancialYearId",
                table: "StoreSetting",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_LanguageId",
                table: "StoreSetting",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_NumberFormatId",
                table: "StoreSetting",
                column: "NumberFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_SignOutDurationId",
                table: "StoreSetting",
                column: "SignOutDurationId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_TaxRateId",
                table: "StoreSetting",
                column: "TaxRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_Variable_AccountingMethodId",
                table: "StoreSetting",
                column: "AccountingMethodId",
                principalTable: "Variable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_Variable_DateFormatId",
                table: "StoreSetting",
                column: "DateFormatId",
                principalTable: "Variable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_Variable_FinancialYearId",
                table: "StoreSetting",
                column: "FinancialYearId",
                principalTable: "Variable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_Variable_LanguageId",
                table: "StoreSetting",
                column: "LanguageId",
                principalTable: "Variable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_Variable_NumberFormatId",
                table: "StoreSetting",
                column: "NumberFormatId",
                principalTable: "Variable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_Variable_SignOutDurationId",
                table: "StoreSetting",
                column: "SignOutDurationId",
                principalTable: "Variable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_Variable_TaxRateId",
                table: "StoreSetting",
                column: "TaxRateId",
                principalTable: "Variable",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_Variable_AccountingMethodId",
                table: "StoreSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_Variable_DateFormatId",
                table: "StoreSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_Variable_FinancialYearId",
                table: "StoreSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_Variable_LanguageId",
                table: "StoreSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_Variable_NumberFormatId",
                table: "StoreSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_Variable_SignOutDurationId",
                table: "StoreSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_Variable_TaxRateId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_AccountingMethodId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_DateFormatId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_FinancialYearId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_LanguageId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_NumberFormatId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_SignOutDurationId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_TaxRateId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "AccountingMethodId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "DateFormatId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsAutoAppliedBillPayment",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsAutoInvoicedUnbilled",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsCloseTheBooks",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsDuplicateBillNo",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsDuplicateCheque",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsDuplicateJournal",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsEnabledAccNumbers",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsOrganisedJob",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsPreFillFormsPrevEnteredContent",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsTrackedClasses",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsTrackedLocations",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "NumberFormatId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "SignOutDurationId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "TaxRateId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "fixMonthofTaxYear",
                table: "StoreSetting");
        }
    }
}
