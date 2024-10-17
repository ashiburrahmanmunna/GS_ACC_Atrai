using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updatepurchaseitemsmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerPOId",
                table: "PurchaseItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_BuyerPOId",
                table: "PurchaseItems",
                column: "BuyerPOId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_BuyerPO_Master_BuyerPOId",
                table: "PurchaseItems",
                column: "BuyerPOId",
                principalTable: "BuyerPO_Master",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_BuyerPO_Master_BuyerPOId",
                table: "PurchaseItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItems_BuyerPOId",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "BuyerPOId",
                table: "PurchaseItems");
        }
    }
}
