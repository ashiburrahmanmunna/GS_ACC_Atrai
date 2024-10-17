using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class VoucherPrefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "Acc_VoucherNoPrefix",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "Acc_VoucherNoPrefix",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "Acc_VoucherNoPrefix",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherNoPrefix_ComId",
                table: "Acc_VoucherNoPrefix",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherNoPrefix_LuserId",
                table: "Acc_VoucherNoPrefix",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherNoPrefix_Company_ComId",
                table: "Acc_VoucherNoPrefix",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherNoPrefix_UserAccount_LuserId",
                table: "Acc_VoucherNoPrefix",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherNoPrefix_Company_ComId",
                table: "Acc_VoucherNoPrefix");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherNoPrefix_UserAccount_LuserId",
                table: "Acc_VoucherNoPrefix");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherNoPrefix_ComId",
                table: "Acc_VoucherNoPrefix");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherNoPrefix_LuserId",
                table: "Acc_VoucherNoPrefix");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Acc_VoucherNoPrefix");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "Acc_VoucherNoPrefix");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "Acc_VoucherNoPrefix");
        }
    }
}
