using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class exportInvoiceMasterUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EPDate",
                table: "ExportInvoiceMaster",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EPNo",
                table: "ExportInvoiceMaster",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExBondDate",
                table: "ExportInvoiceMaster",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExBondNo",
                table: "ExportInvoiceMaster",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EPDate",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropColumn(
                name: "EPNo",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropColumn(
                name: "ExBondDate",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropColumn(
                name: "ExBondNo",
                table: "ExportInvoiceMaster");
        }
    }
}
