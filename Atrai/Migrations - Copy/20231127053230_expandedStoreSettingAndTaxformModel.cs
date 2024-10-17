using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class expandedStoreSettingAndTaxformModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusinessIdNo",
                table: "StoreSetting",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerFacingAddress",
                table: "StoreSetting",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerFacingCityAddress",
                table: "StoreSetting",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerFacingState",
                table: "StoreSetting",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerFacingZipCode",
                table: "StoreSetting",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalAddress",
                table: "StoreSetting",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalCityAddress",
                table: "StoreSetting",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalName",
                table: "StoreSetting",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalState",
                table: "StoreSetting",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalZipCode",
                table: "StoreSetting",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "StoreSetting",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaxFormId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "StoreSetting",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "customerFacingEmail",
                table: "StoreSetting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "vat",
                table: "StoreSetting",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaxForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxFormName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsInActive = table.Column<bool>(type: "bit", maxLength: 200, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxForm", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_TaxFormId",
                table: "StoreSetting",
                column: "TaxFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_TaxForm_TaxFormId",
                table: "StoreSetting",
                column: "TaxFormId",
                principalTable: "TaxForm",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_TaxForm_TaxFormId",
                table: "StoreSetting");

            migrationBuilder.DropTable(
                name: "TaxForm");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_TaxFormId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "BusinessIdNo",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "CustomerFacingAddress",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "CustomerFacingCityAddress",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "CustomerFacingState",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "CustomerFacingZipCode",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "LegalAddress",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "LegalCityAddress",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "LegalName",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "LegalState",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "LegalZipCode",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "State",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "TaxFormId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "customerFacingEmail",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "vat",
                table: "StoreSetting");
        }
    }
}
