using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class addDocTypeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctypeId",
                table: "Com_proformaInvoice",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Com_proformaInvoice_DoctypeId",
                table: "Com_proformaInvoice",
                column: "DoctypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_DocType_DoctypeId",
                table: "Com_proformaInvoice",
                column: "DoctypeId",
                principalTable: "DocType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_DocType_DoctypeId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropIndex(
                name: "IX_Com_proformaInvoice_DoctypeId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropColumn(
                name: "DoctypeId",
                table: "Com_proformaInvoice");
        }
    }
}
