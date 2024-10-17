using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class modifyPackingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "ExportInvoicePackingList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "ExportInvoicePackingList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoicePackingList_ColorId",
                table: "ExportInvoicePackingList",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoicePackingList_SizeId",
                table: "ExportInvoicePackingList",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoicePackingList_Colors_ColorId",
                table: "ExportInvoicePackingList",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoicePackingList_Sizes_SizeId",
                table: "ExportInvoicePackingList",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoicePackingList_Colors_ColorId",
                table: "ExportInvoicePackingList");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoicePackingList_Sizes_SizeId",
                table: "ExportInvoicePackingList");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoicePackingList_ColorId",
                table: "ExportInvoicePackingList");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoicePackingList_SizeId",
                table: "ExportInvoicePackingList");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "ExportInvoicePackingList");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "ExportInvoicePackingList");
        }
    }
}
