using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class AssetLiabilityHead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssetLiabilityAccountId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_AssetLiabilityAccountId",
                table: "AccountsDailyTransaction",
                column: "AssetLiabilityAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_AssetLiabilityAccountId",
                table: "AccountsDailyTransaction",
                column: "AssetLiabilityAccountId",
                principalTable: "AccountHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_AssetLiabilityAccountId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_AssetLiabilityAccountId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "AssetLiabilityAccountId",
                table: "AccountsDailyTransaction");
        }
    }
}
