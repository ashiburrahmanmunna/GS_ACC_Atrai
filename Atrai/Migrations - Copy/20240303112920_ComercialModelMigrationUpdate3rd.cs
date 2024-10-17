using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class ComercialModelMigrationUpdate3rd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_CommercialInvoice_UnitMaster_UnitMasterId",
                table: "COM_CommercialInvoice");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CommercialInvoice_Unit_UnitMasterId",
                table: "COM_CommercialInvoice",
                column: "UnitMasterId",
                principalTable: "Unit",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_CommercialInvoice_Unit_UnitMasterId",
                table: "COM_CommercialInvoice");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CommercialInvoice_UnitMaster_UnitMasterId",
                table: "COM_CommercialInvoice",
                column: "UnitMasterId",
                principalTable: "UnitMaster",
                principalColumn: "Id");
        }
    }
}
