using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class salesexchangeitemsdisproportion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "SalesExchangeItems",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "IndDiscountProportionExc",
                table: "SalesExchangeItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseItemsId",
                table: "SalesExchangeItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesExchangeItems_PurchaseItemsId",
                table: "SalesExchangeItems",
                column: "PurchaseItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesExchangeItems_PurchaseItems_PurchaseItemsId",
                table: "SalesExchangeItems",
                column: "PurchaseItemsId",
                principalTable: "PurchaseItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesExchangeItems_PurchaseItems_PurchaseItemsId",
                table: "SalesExchangeItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesExchangeItems_PurchaseItemsId",
                table: "SalesExchangeItems");

            migrationBuilder.DropColumn(
                name: "IndDiscountProportionExc",
                table: "SalesExchangeItems");

            migrationBuilder.DropColumn(
                name: "PurchaseItemsId",
                table: "SalesExchangeItems");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "SalesExchangeItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
