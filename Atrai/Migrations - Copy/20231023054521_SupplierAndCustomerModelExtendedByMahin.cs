using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class SupplierAndCustomerModelExtendedByMahin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccIdExpenseCategory",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNo",
                table: "Supplier",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AsOf",
                table: "Supplier",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingRate",
                table: "Supplier",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessIdNo",
                table: "Supplier",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Supplier",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Supplier",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Supplier",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Supplier",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Supplier",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNo",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Other",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTermsId",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Supplier",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Supplier",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suffix",
                table: "Supplier",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierFilePath",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Supplier",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccIdExpenseCategory",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNo",
                table: "Customer",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AsOf",
                table: "Customer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingRate",
                table: "Customer",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessIdNo",
                table: "Customer",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Customer",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Customer",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customer",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customer",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Customer",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNo",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Other",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTermsId",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Customer",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suffix",
                table: "Customer",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierFilePath",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Customer",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_AccIdExpenseCategory",
                table: "Supplier",
                column: "AccIdExpenseCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_PaymentTermsId",
                table: "Supplier",
                column: "PaymentTermsId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AccIdExpenseCategory",
                table: "Customer",
                column: "AccIdExpenseCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PaymentTermsId",
                table: "Customer",
                column: "PaymentTermsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AccountHead_AccIdExpenseCategory",
                table: "Customer",
                column: "AccIdExpenseCategory",
                principalTable: "AccountHead",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_PaymentTerms_PaymentTermsId",
                table: "Customer",
                column: "PaymentTermsId",
                principalTable: "PaymentTerms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_AccountHead_AccIdExpenseCategory",
                table: "Supplier",
                column: "AccIdExpenseCategory",
                principalTable: "AccountHead",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_PaymentTerms_PaymentTermsId",
                table: "Supplier",
                column: "PaymentTermsId",
                principalTable: "PaymentTerms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AccountHead_AccIdExpenseCategory",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_PaymentTerms_PaymentTermsId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_AccountHead_AccIdExpenseCategory",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_PaymentTerms_PaymentTermsId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_AccIdExpenseCategory",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_PaymentTermsId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Customer_AccIdExpenseCategory",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_PaymentTermsId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "AccIdExpenseCategory",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "AccountNo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "AsOf",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "BillingRate",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "BusinessIdNo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "MobileNo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Other",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "PaymentTermsId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Suffix",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "SupplierFilePath",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "AccIdExpenseCategory",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "AccountNo",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "AsOf",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "BillingRate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "BusinessIdNo",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "MobileNo",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Other",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PaymentTermsId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Suffix",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "SupplierFilePath",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Customer");
        }
    }
}
