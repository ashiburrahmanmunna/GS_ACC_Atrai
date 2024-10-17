using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class purchaseitemsidLInked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseItemsId",
                table: "PurchaseItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_PurchaseItemsId",
                table: "PurchaseItems",
                column: "PurchaseItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_PurchaseItems_PurchaseItemsId",
                table: "PurchaseItems",
                column: "PurchaseItemsId",
                principalTable: "PurchaseItems",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_PurchaseItems_PurchaseItemsId",
                table: "PurchaseItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItems_PurchaseItemsId",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "PurchaseItemsId",
                table: "PurchaseItems");
        }
    }
}
