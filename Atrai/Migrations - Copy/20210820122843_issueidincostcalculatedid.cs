using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class issueidincostcalculatedid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_Issue_IssueModelId",
                table: "CostCalculated");

            migrationBuilder.RenameColumn(
                name: "IssueModelId",
                table: "CostCalculated",
                newName: "IssueId");

            migrationBuilder.RenameIndex(
                name: "IX_CostCalculated_IssueModelId",
                table: "CostCalculated",
                newName: "IX_CostCalculated_IssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_Issue_IssueId",
                table: "CostCalculated",
                column: "IssueId",
                principalTable: "Issue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_Issue_IssueId",
                table: "CostCalculated");

            migrationBuilder.RenameColumn(
                name: "IssueId",
                table: "CostCalculated",
                newName: "IssueModelId");

            migrationBuilder.RenameIndex(
                name: "IX_CostCalculated_IssueId",
                table: "CostCalculated",
                newName: "IX_CostCalculated_IssueModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_Issue_IssueModelId",
                table: "CostCalculated",
                column: "IssueModelId",
                principalTable: "Issue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
