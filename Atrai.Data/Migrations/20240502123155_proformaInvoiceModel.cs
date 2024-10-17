using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class proformaInvoiceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SecondaryUnitId",
                table: "Com_proformaInvoice",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Com_proformaInvoice_SecondaryUnitId",
                table: "Com_proformaInvoice",
                column: "SecondaryUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_Unit_SecondaryUnitId",
                table: "Com_proformaInvoice",
                column: "SecondaryUnitId",
                principalTable: "Unit",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_Unit_SecondaryUnitId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropIndex(
                name: "IX_Com_proformaInvoice_SecondaryUnitId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropColumn(
                name: "SecondaryUnitId",
                table: "Com_proformaInvoice");
        }
    }
}
