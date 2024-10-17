using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeStyleAndBuyerPO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TermsName",
                table: "TermsMain",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "GoodsDescription",
                table: "Style",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StyleName",
                table: "Style",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TermName",
                table: "PaymentTerms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "FabricName",
                table: "BuyerPO_Master",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FabricNo",
                table: "BuyerPO_Master",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "BuyerPO_Master",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ShipmentDate",
                table: "BuyerPO_Master",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoodsDescription",
                table: "Style");

            migrationBuilder.DropColumn(
                name: "StyleName",
                table: "Style");

            migrationBuilder.DropColumn(
                name: "FabricName",
                table: "BuyerPO_Master");

            migrationBuilder.DropColumn(
                name: "FabricNo",
                table: "BuyerPO_Master");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "BuyerPO_Master");

            migrationBuilder.DropColumn(
                name: "ShipmentDate",
                table: "BuyerPO_Master");

            migrationBuilder.AlterColumn<string>(
                name: "TermsName",
                table: "TermsMain",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TermName",
                table: "PaymentTerms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
