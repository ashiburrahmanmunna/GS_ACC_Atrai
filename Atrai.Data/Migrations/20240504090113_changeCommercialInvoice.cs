using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeCommercialInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SecondaryQuantity",
                table: "COM_CommercialInvoice",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryUnitId",
                table: "COM_CommercialInvoice",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_COM_CommercialInvoice_SecondaryUnitId",
                table: "COM_CommercialInvoice",
                column: "SecondaryUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CommercialInvoice_Unit_SecondaryUnitId",
                table: "COM_CommercialInvoice",
                column: "SecondaryUnitId",
                principalTable: "Unit",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_CommercialInvoice_Unit_SecondaryUnitId",
                table: "COM_CommercialInvoice");

            migrationBuilder.DropIndex(
                name: "IX_COM_CommercialInvoice_SecondaryUnitId",
                table: "COM_CommercialInvoice");

            migrationBuilder.DropColumn(
                name: "SecondaryQuantity",
                table: "COM_CommercialInvoice");

            migrationBuilder.DropColumn(
                name: "SecondaryUnitId",
                table: "COM_CommercialInvoice");
        }
    }
}
