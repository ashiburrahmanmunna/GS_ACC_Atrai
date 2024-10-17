using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSupplierImportCI_Master : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "ImportCI_Master",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Master_SupplierId",
                table: "ImportCI_Master",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportCI_Master_Supplier_SupplierId",
                table: "ImportCI_Master",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportCI_Master_Supplier_SupplierId",
                table: "ImportCI_Master");

            migrationBuilder.DropIndex(
                name: "IX_ImportCI_Master_SupplierId",
                table: "ImportCI_Master");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "ImportCI_Master");
        }
    }
}
