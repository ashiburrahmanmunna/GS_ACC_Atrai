using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class PurchaseTagTableCreateUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchaseTag_Purchase_VoucherId",
                table: "purchaseTag");

            migrationBuilder.DropIndex(
                name: "IX_purchaseTag_VoucherId",
                table: "purchaseTag");

            migrationBuilder.DropColumn(
                name: "VoucherId",
                table: "purchaseTag");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseTag_PurchaseId",
                table: "purchaseTag",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseTag_Purchase_PurchaseId",
                table: "purchaseTag",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchaseTag_Purchase_PurchaseId",
                table: "purchaseTag");

            migrationBuilder.DropIndex(
                name: "IX_purchaseTag_PurchaseId",
                table: "purchaseTag");

            migrationBuilder.AddColumn<int>(
                name: "VoucherId",
                table: "purchaseTag",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_purchaseTag_VoucherId",
                table: "purchaseTag",
                column: "VoucherId");

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseTag_Purchase_VoucherId",
                table: "purchaseTag",
                column: "VoucherId",
                principalTable: "Purchase",
                principalColumn: "Id");
        }
    }
}
