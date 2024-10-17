using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class transactionparentid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentTransactionId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_ParentTransactionId",
                table: "AccountsDailyTransaction",
                column: "ParentTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_AccountsDailyTransaction_ParentTransactionId",
                table: "AccountsDailyTransaction",
                column: "ParentTransactionId",
                principalTable: "AccountsDailyTransaction",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_AccountsDailyTransaction_ParentTransactionId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_ParentTransactionId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "ParentTransactionId",
                table: "AccountsDailyTransaction");
        }
    }
}
