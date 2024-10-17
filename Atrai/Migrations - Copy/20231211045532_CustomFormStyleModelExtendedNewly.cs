using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class CustomFormStyleModelExtendedNewly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComRegNo",
                table: "CustomFormStyle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Invoice",
                table: "CustomFormStyle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBillingAddress",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBusinessAddrsShow",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBusinessNameShow",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsComRegShow",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCustomTranUsed",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCustomVatNo",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDueDate",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailShow",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFormNumbers",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPhoneShow",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShipping",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWebsiteShow",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TaxInvoice",
                table: "CustomFormStyle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "CustomFormStyle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComRegNo",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "Invoice",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsBillingAddress",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsBusinessAddrsShow",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsBusinessNameShow",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsComRegShow",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsCustomTranUsed",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsCustomVatNo",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsDueDate",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsEmailShow",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsFormNumbers",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsPhoneShow",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsShipping",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsWebsiteShow",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "TaxInvoice",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "CustomFormStyle");
        }
    }
}
