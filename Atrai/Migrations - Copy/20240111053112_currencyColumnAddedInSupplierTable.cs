using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class currencyColumnAddedInSupplierTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Supplier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CurrencyId",
                table: "Supplier",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Country_CurrencyId",
                table: "Supplier",
                column: "CurrencyId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Country_CurrencyId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_CurrencyId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Supplier");
        }
    }
}
