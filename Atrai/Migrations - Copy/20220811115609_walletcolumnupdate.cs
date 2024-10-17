using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class walletcolumnupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditBalanceId",
                table: "Wallet",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPost",
                table: "Wallet",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSystem",
                table: "Wallet",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "CreditBalance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_CreditBalanceId",
                table: "Wallet",
                column: "CreditBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditBalance_LuserId",
                table: "CreditBalance",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditBalance_UserAccount_LuserId",
                table: "CreditBalance",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_CreditBalance_CreditBalanceId",
                table: "Wallet",
                column: "CreditBalanceId",
                principalTable: "CreditBalance",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditBalance_UserAccount_LuserId",
                table: "CreditBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_CreditBalance_CreditBalanceId",
                table: "Wallet");

            migrationBuilder.DropIndex(
                name: "IX_Wallet_CreditBalanceId",
                table: "Wallet");

            migrationBuilder.DropIndex(
                name: "IX_CreditBalance_LuserId",
                table: "CreditBalance");

            migrationBuilder.DropColumn(
                name: "CreditBalanceId",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "IsPost",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "IsSystem",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "CreditBalance");
        }
    }
}
