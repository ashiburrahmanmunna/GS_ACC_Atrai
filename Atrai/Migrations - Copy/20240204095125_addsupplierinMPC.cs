using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class addsupplierinMPC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "MASTERPO_Consumption",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_Consumption_SupplierId",
                table: "MASTERPO_Consumption",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_MASTERPO_Consumption_Supplier_SupplierId",
                table: "MASTERPO_Consumption",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MASTERPO_Consumption_Supplier_SupplierId",
                table: "MASTERPO_Consumption");

            migrationBuilder.DropIndex(
                name: "IX_MASTERPO_Consumption_SupplierId",
                table: "MASTERPO_Consumption");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "MASTERPO_Consumption");
        }
    }
}
