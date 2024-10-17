using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class footerRelatedColumnsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FooterText",
                table: "CustomFormStyle",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterTextSize",
                table: "CustomFormStyle",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FootertextPlacement",
                table: "CustomFormStyle",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeposited",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscounted",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEstimateSummary",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTaxSummary",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MessageToCustomer",
                table: "CustomFormStyle",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterText",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "FooterTextSize",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "FootertextPlacement",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsDeposited",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsDiscounted",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsEstimateSummary",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsTaxSummary",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "MessageToCustomer",
                table: "CustomFormStyle");
        }
    }
}
