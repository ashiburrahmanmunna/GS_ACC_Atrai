using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeTransactionApprovalStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CheckApproverId",
                table: "TransactionApprovalStatus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisApproverId",
                table: "TransactionApprovalStatus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinalApproverId",
                table: "TransactionApprovalStatus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisApproved",
                table: "TransactionApprovalStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "VerifyApproverId",
                table: "TransactionApprovalStatus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionApprovalStatus_CheckApproverId",
                table: "TransactionApprovalStatus",
                column: "CheckApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionApprovalStatus_DisApproverId",
                table: "TransactionApprovalStatus",
                column: "DisApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionApprovalStatus_FinalApproverId",
                table: "TransactionApprovalStatus",
                column: "FinalApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionApprovalStatus_VerifyApproverId",
                table: "TransactionApprovalStatus",
                column: "VerifyApproverId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionApprovalStatus_UserAccount_CheckApproverId",
                table: "TransactionApprovalStatus",
                column: "CheckApproverId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionApprovalStatus_UserAccount_DisApproverId",
                table: "TransactionApprovalStatus",
                column: "DisApproverId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionApprovalStatus_UserAccount_FinalApproverId",
                table: "TransactionApprovalStatus",
                column: "FinalApproverId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionApprovalStatus_UserAccount_VerifyApproverId",
                table: "TransactionApprovalStatus",
                column: "VerifyApproverId",
                principalTable: "UserAccount",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionApprovalStatus_UserAccount_CheckApproverId",
                table: "TransactionApprovalStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionApprovalStatus_UserAccount_DisApproverId",
                table: "TransactionApprovalStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionApprovalStatus_UserAccount_FinalApproverId",
                table: "TransactionApprovalStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionApprovalStatus_UserAccount_VerifyApproverId",
                table: "TransactionApprovalStatus");

            migrationBuilder.DropIndex(
                name: "IX_TransactionApprovalStatus_CheckApproverId",
                table: "TransactionApprovalStatus");

            migrationBuilder.DropIndex(
                name: "IX_TransactionApprovalStatus_DisApproverId",
                table: "TransactionApprovalStatus");

            migrationBuilder.DropIndex(
                name: "IX_TransactionApprovalStatus_FinalApproverId",
                table: "TransactionApprovalStatus");

            migrationBuilder.DropIndex(
                name: "IX_TransactionApprovalStatus_VerifyApproverId",
                table: "TransactionApprovalStatus");

            migrationBuilder.DropColumn(
                name: "CheckApproverId",
                table: "TransactionApprovalStatus");

            migrationBuilder.DropColumn(
                name: "DisApproverId",
                table: "TransactionApprovalStatus");

            migrationBuilder.DropColumn(
                name: "FinalApproverId",
                table: "TransactionApprovalStatus");

            migrationBuilder.DropColumn(
                name: "IsDisApproved",
                table: "TransactionApprovalStatus");

            migrationBuilder.DropColumn(
                name: "VerifyApproverId",
                table: "TransactionApprovalStatus");
        }
    }
}
