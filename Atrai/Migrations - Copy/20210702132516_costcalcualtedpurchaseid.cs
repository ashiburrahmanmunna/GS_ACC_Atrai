using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class costcalcualtedpurchaseid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "CostCalculated",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_PurchaseId",
                table: "CostCalculated",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_Purchase_PurchaseId",
                table: "CostCalculated",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_Purchase_PurchaseId",
                table: "CostCalculated");

            migrationBuilder.DropIndex(
                name: "IX_CostCalculated_PurchaseId",
                table: "CostCalculated");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "CostCalculated");
        }
    }
}
