using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class purchaseitemid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseBatchItems_PurchaseItems_PurchseItemId",
                table: "PurchaseBatchItems");

            migrationBuilder.RenameColumn(
                name: "PurchseItemId",
                table: "PurchaseBatchItems",
                newName: "PurchaseItemId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseBatchItems_PurchseItemId",
                table: "PurchaseBatchItems",
                newName: "IX_PurchaseBatchItems_PurchaseItemId");

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "PurchaseBatchItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseBatchItems_PurchaseItems_PurchaseItemId",
                table: "PurchaseBatchItems",
                column: "PurchaseItemId",
                principalTable: "PurchaseItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseBatchItems_PurchaseItems_PurchaseItemId",
                table: "PurchaseBatchItems");

            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "PurchaseBatchItems");

            migrationBuilder.RenameColumn(
                name: "PurchaseItemId",
                table: "PurchaseBatchItems",
                newName: "PurchseItemId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseBatchItems_PurchaseItemId",
                table: "PurchaseBatchItems",
                newName: "IX_PurchaseBatchItems_PurchseItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseBatchItems_PurchaseItems_PurchseItemId",
                table: "PurchaseBatchItems",
                column: "PurchseItemId",
                principalTable: "PurchaseItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
