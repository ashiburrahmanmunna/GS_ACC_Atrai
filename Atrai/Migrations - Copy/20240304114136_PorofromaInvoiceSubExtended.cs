using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class PorofromaInvoiceSubExtended : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoice_Sub_ItemDesc_ItemDescId",
                table: "COM_ProformaInvoice_Sub");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoice_Sub_ItemDescription_ItemDescId",
                table: "COM_ProformaInvoice_Sub",
                column: "ItemDescId",
                principalTable: "ItemDescription",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoice_Sub_ItemDescription_ItemDescId",
                table: "COM_ProformaInvoice_Sub");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoice_Sub_ItemDesc_ItemDescId",
                table: "COM_ProformaInvoice_Sub",
                column: "ItemDescId",
                principalTable: "ItemDesc",
                principalColumn: "Id");
        }
    }
}
