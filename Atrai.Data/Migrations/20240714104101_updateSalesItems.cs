using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateSalesItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ConversionRate",
                table: "SalesItems",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "InputQuantity",
                table: "SalesItems",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrimaryUnitId",
                table: "SalesItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryUnitId",
                table: "SalesItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_PrimaryUnitId",
                table: "SalesItems",
                column: "PrimaryUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_SecondaryUnitId",
                table: "SalesItems",
                column: "SecondaryUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesItems_Unit_PrimaryUnitId",
                table: "SalesItems",
                column: "PrimaryUnitId",
                principalTable: "Unit",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesItems_Unit_SecondaryUnitId",
                table: "SalesItems",
                column: "SecondaryUnitId",
                principalTable: "Unit",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesItems_Unit_PrimaryUnitId",
                table: "SalesItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesItems_Unit_SecondaryUnitId",
                table: "SalesItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesItems_PrimaryUnitId",
                table: "SalesItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesItems_SecondaryUnitId",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "ConversionRate",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "InputQuantity",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "PrimaryUnitId",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "SecondaryUnitId",
                table: "SalesItems");
        }
    }
}
