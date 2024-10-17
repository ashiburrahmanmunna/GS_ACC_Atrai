using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updateAdvanceTrasactionTrackingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "AdvanceTrasactionTracking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceTrasactionTracking_PurchaseId",
                table: "AdvanceTrasactionTracking",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvanceTrasactionTracking_Purchase_PurchaseId",
                table: "AdvanceTrasactionTracking",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvanceTrasactionTracking_Purchase_PurchaseId",
                table: "AdvanceTrasactionTracking");

            migrationBuilder.DropIndex(
                name: "IX_AdvanceTrasactionTracking_PurchaseId",
                table: "AdvanceTrasactionTracking");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "AdvanceTrasactionTracking");
        }
    }
}
