using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class modifyExportDetailsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoxCategoryId",
                table: "ExportInvoiceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartoonFrom",
                table: "ExportInvoiceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartoonTo",
                table: "ExportInvoiceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceDetails_BoxCategoryId",
                table: "ExportInvoiceDetails",
                column: "BoxCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceDetails_BoxCategory_BoxCategoryId",
                table: "ExportInvoiceDetails",
                column: "BoxCategoryId",
                principalTable: "BoxCategory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceDetails_BoxCategory_BoxCategoryId",
                table: "ExportInvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoiceDetails_BoxCategoryId",
                table: "ExportInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "BoxCategoryId",
                table: "ExportInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "CartoonFrom",
                table: "ExportInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "CartoonTo",
                table: "ExportInvoiceDetails");
        }
    }
}
