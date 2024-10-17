using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class transactionmodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_AccountHeadId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_ReceivedPaymentTypeHeadId",
                table: "AccountsDailyTransaction");

            migrationBuilder.RenameColumn(
                name: "ReceivedPaymentTypeHeadId",
                table: "AccountsDailyTransaction",
                newName: "AccountPayTypeId");

            migrationBuilder.RenameColumn(
                name: "AccountHeadId",
                table: "AccountsDailyTransaction",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsDailyTransaction_ReceivedPaymentTypeHeadId",
                table: "AccountsDailyTransaction",
                newName: "IX_AccountsDailyTransaction_AccountPayTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsDailyTransaction_AccountHeadId",
                table: "AccountsDailyTransaction",
                newName: "IX_AccountsDailyTransaction_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_AccountId",
                table: "AccountsDailyTransaction",
                column: "AccountId",
                principalTable: "AccountHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_AccountPayTypeId",
                table: "AccountsDailyTransaction",
                column: "AccountPayTypeId",
                principalTable: "AccountHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_AccountId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_AccountPayTypeId",
                table: "AccountsDailyTransaction");

            migrationBuilder.RenameColumn(
                name: "AccountPayTypeId",
                table: "AccountsDailyTransaction",
                newName: "ReceivedPaymentTypeHeadId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "AccountsDailyTransaction",
                newName: "AccountHeadId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsDailyTransaction_AccountPayTypeId",
                table: "AccountsDailyTransaction",
                newName: "IX_AccountsDailyTransaction_ReceivedPaymentTypeHeadId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsDailyTransaction_AccountId",
                table: "AccountsDailyTransaction",
                newName: "IX_AccountsDailyTransaction_AccountHeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_AccountHeadId",
                table: "AccountsDailyTransaction",
                column: "AccountHeadId",
                principalTable: "AccountHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_ReceivedPaymentTypeHeadId",
                table: "AccountsDailyTransaction",
                column: "ReceivedPaymentTypeHeadId",
                principalTable: "AccountHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
