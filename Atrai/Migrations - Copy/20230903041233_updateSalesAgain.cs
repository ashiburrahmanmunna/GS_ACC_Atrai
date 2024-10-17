using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class updateSalesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTax",
                table: "SalesItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ServiceDate",
                table: "SalesItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Sales",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageInvoice",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageStatement",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ShippingDate",
                table: "Sales",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingTo",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingVia",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SubTotal",
                table: "Sales",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TaxAmount",
                table: "Sales",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TrackingNo",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTax",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "ServiceDate",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "MessageInvoice",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "MessageStatement",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ShippingDate",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ShippingTo",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ShippingVia",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "TrackingNo",
                table: "Sales");
        }
    }
}
