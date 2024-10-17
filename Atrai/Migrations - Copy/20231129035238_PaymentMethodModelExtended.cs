using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class PaymentMethodModelExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "PaymentMethod",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "PaymentMethod",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalAddress",
                table: "PaymentMethod",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalCityAddress",
                table: "PaymentMethod",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalState",
                table: "PaymentMethod",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalZipCode",
                table: "PaymentMethod",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "PaymentMethod",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "PaymentMethod",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "City",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "LegalAddress",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "LegalCityAddress",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "LegalState",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "LegalZipCode",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "State",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "PaymentMethod");
        }
    }
}
