using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class AddSalesColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalEmailOptions",
                table: "StoreSetting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bcc",
                table: "StoreSetting",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cc",
                table: "StoreSetting",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryMethod",
                table: "StoreSetting",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocTypeId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailMessage",
                table: "StoreSetting",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailSubjectLine",
                table: "StoreSetting",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GreetingAppeal",
                table: "StoreSetting",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GreetingNameFormat",
                table: "StoreSetting",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCopyEmail",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCreateMultiplePartialInvoice",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCustomTransactionNumber",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeposit",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscount",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsListAllTransaction",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsListEachTransaction",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPdfAttached",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsServiceDate",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShipping",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShowFullDetailsInEmail",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShowProductServiceColumn",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShowSku",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShowSummaryInEmail",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTags",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrackQtyOnHand",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTracktyRatePrice",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PaymentInstructions",
                table: "StoreSetting",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReminderOneDays",
                table: "StoreSetting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReminderOneDueDate",
                table: "StoreSetting",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReminderOneGreetingAppeal",
                table: "StoreSetting",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReminderOneGreetingNameFormat",
                table: "StoreSetting",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReminderOneMessage",
                table: "StoreSetting",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReminderOneSubjectLine",
                table: "StoreSetting",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReminderThreeDays",
                table: "StoreSetting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReminderThreeDueDate",
                table: "StoreSetting",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ReminderThreeGreetingAppeal",
                table: "StoreSetting",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReminderThreeGreetingNameFormat",
                table: "StoreSetting",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReminderThreeMessage",
                table: "StoreSetting",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReminderThreeSubjectLine",
                table: "StoreSetting",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReminderTwoDays",
                table: "StoreSetting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReminderTwoDueDate",
                table: "StoreSetting",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ReminderTwoGreetingAppeal",
                table: "StoreSetting",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReminderTwoGreetingNameFormat",
                table: "StoreSetting",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReminderTwoMessage",
                table: "StoreSetting",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReminderTwoSubjectLine",
                table: "StoreSetting",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TermsId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_DocTypeId",
                table: "StoreSetting",
                column: "DocTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_TermsId",
                table: "StoreSetting",
                column: "TermsId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_DocType_DocTypeId",
                table: "StoreSetting",
                column: "DocTypeId",
                principalTable: "DocType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_PurchaseTerms_TermsId",
                table: "StoreSetting",
                column: "TermsId",
                principalTable: "PurchaseTerms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_DocType_DocTypeId",
                table: "StoreSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_PurchaseTerms_TermsId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_DocTypeId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_TermsId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "AdditionalEmailOptions",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "Bcc",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "Cc",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "DeliveryMethod",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "DocTypeId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "EmailMessage",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "EmailSubjectLine",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "GreetingAppeal",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "GreetingNameFormat",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsCopyEmail",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsCreateMultiplePartialInvoice",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsCustomTransactionNumber",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsDeposit",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsDiscount",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsListAllTransaction",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsListEachTransaction",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsPdfAttached",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsServiceDate",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsShipping",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsShowFullDetailsInEmail",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsShowProductServiceColumn",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsShowSku",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsShowSummaryInEmail",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsTags",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsTrackQtyOnHand",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsTracktyRatePrice",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "PaymentInstructions",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReminderOneDays",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReminderOneDueDate",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReminderOneGreetingAppeal",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReminderOneGreetingNameFormat",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReminderOneMessage",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReminderOneSubjectLine",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReminderThreeDays",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReminderThreeDueDate",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReminderThreeGreetingAppeal",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReminderThreeGreetingNameFormat",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReminderThreeMessage",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReminderThreeSubjectLine",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReminderTwoDays",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReminderTwoDueDate",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReminderTwoGreetingAppeal",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReminderTwoGreetingNameFormat",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReminderTwoMessage",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReminderTwoSubjectLine",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "TermsId",
                table: "StoreSetting");
        }
    }
}
