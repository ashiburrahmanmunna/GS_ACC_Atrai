using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class ComercialModelMigrationUpdate2nd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_CommercialInvoice_ItemDesc_ItemDescId",
                table: "COM_CommercialInvoice");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CommercialInvoice_ItemDescription_ItemDescId",
                table: "COM_CommercialInvoice",
                column: "ItemDescId",
                principalTable: "ItemDescription",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_CommercialInvoice_ItemDescription_ItemDescId",
                table: "COM_CommercialInvoice");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CommercialInvoice_ItemDesc_ItemDescId",
                table: "COM_CommercialInvoice",
                column: "ItemDescId",
                principalTable: "ItemDesc",
                principalColumn: "Id");
        }
    }
}
