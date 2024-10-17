using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class purchaseidreturn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "PurchaseReturn",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturn_PurchaseId",
                table: "PurchaseReturn",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturn_Purchase_PurchaseId",
                table: "PurchaseReturn",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturn_Purchase_PurchaseId",
                table: "PurchaseReturn");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturn_PurchaseId",
                table: "PurchaseReturn");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "PurchaseReturn");
        }
    }
}
