using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class companyModelExpanded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusinessIdNo",
                table: "Company",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerFacingAddress",
                table: "Company",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerFacingCityAddress",
                table: "Company",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerFacingState",
                table: "Company",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerFacingZipCode",
                table: "Company",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalAddress",
                table: "Company",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalCityAddress",
                table: "Company",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalName",
                table: "Company",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalState",
                table: "Company",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalZipCode",
                table: "Company",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Company",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Company",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "customerFacingEmail",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "vat",
                table: "Company",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessIdNo",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CustomerFacingAddress",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CustomerFacingCityAddress",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CustomerFacingState",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CustomerFacingZipCode",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "LegalAddress",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "LegalCityAddress",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "LegalName",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "LegalState",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "LegalZipCode",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "customerFacingEmail",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "vat",
                table: "Company");
        }
    }
}
