using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class transferintransferout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransferIn",
                table: "CostCalculated",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransferOut",
                table: "CostCalculated",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InternetUserId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IssueId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_InternetUserId",
                table: "AccountsDailyTransaction",
                column: "InternetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_IssueId",
                table: "AccountsDailyTransaction",
                column: "IssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_InternetUser_InternetUserId",
                table: "AccountsDailyTransaction",
                column: "InternetUserId",
                principalTable: "InternetUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_Issue_IssueId",
                table: "AccountsDailyTransaction",
                column: "IssueId",
                principalTable: "Issue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_InternetUser_InternetUserId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_Issue_IssueId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_InternetUserId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_IssueId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "TransferIn",
                table: "CostCalculated");

            migrationBuilder.DropColumn(
                name: "TransferOut",
                table: "CostCalculated");

            migrationBuilder.DropColumn(
                name: "InternetUserId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "IssueId",
                table: "AccountsDailyTransaction");
        }
    }
}
