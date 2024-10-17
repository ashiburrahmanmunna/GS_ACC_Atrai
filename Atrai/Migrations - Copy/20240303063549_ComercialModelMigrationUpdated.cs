using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class ComercialModelMigrationUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "COM_CommercialInvoice");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "COM_CommercialInvoice");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "COM_CommercialInvoice");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "COM_CommercialInvoice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "COM_CommercialInvoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "COM_CommercialInvoice",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "COM_CommercialInvoice",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "COM_CommercialInvoice",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
