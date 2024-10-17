using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class addTdsandTaxAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TDS",
                table: "PurchaseItems",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TaxAmount",
                table: "PurchaseItems",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TDS",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "PurchaseItems");
        }
    }
}
