using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class SupplierAndCustomerModelExtended : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Country_CurrencyId",
                table: "Supplier");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "Supplier",
                newName: "SupplierCurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Supplier_CurrencyId",
                table: "Supplier",
                newName: "IX_Supplier_SupplierCurrencyId");

            migrationBuilder.AddColumn<int>(
                name: "CustomerCurrencyId",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerCurrencyId",
                table: "Customer",
                column: "CustomerCurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Country_CustomerCurrencyId",
                table: "Customer",
                column: "CustomerCurrencyId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Country_SupplierCurrencyId",
                table: "Supplier",
                column: "SupplierCurrencyId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Country_CustomerCurrencyId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Country_SupplierCurrencyId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CustomerCurrencyId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CustomerCurrencyId",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "SupplierCurrencyId",
                table: "Supplier",
                newName: "CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Supplier_SupplierCurrencyId",
                table: "Supplier",
                newName: "IX_Supplier_CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Country_CurrencyId",
                table: "Supplier",
                column: "CurrencyId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
