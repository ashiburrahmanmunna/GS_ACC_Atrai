using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatePurchaseItemsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ConversionRate",
                table: "PurchaseItems",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "InputQuantity",
                table: "PurchaseItems",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrimaryUnitId",
                table: "PurchaseItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryUnitId",
                table: "PurchaseItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "PurchaseItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_PrimaryUnitId",
                table: "PurchaseItems",
                column: "PrimaryUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_SecondaryUnitId",
                table: "PurchaseItems",
                column: "SecondaryUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_Unit_PrimaryUnitId",
                table: "PurchaseItems",
                column: "PrimaryUnitId",
                principalTable: "Unit",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_Unit_SecondaryUnitId",
                table: "PurchaseItems",
                column: "SecondaryUnitId",
                principalTable: "Unit",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_Unit_PrimaryUnitId",
                table: "PurchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_Unit_SecondaryUnitId",
                table: "PurchaseItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItems_PrimaryUnitId",
                table: "PurchaseItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItems_SecondaryUnitId",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "ConversionRate",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "InputQuantity",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "PrimaryUnitId",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "SecondaryUnitId",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "PurchaseItems");
        }
    }
}
