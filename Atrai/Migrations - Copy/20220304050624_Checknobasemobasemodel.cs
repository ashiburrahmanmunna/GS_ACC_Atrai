using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class Checknobasemobasemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "Acc_VoucherSubSection",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "Acc_VoucherSubSection",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "Acc_VoucherSubSection",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "Acc_VoucherSubCheckno",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "Acc_VoucherSubCheckno",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "Acc_VoucherSubCheckno",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubSection_ComId",
                table: "Acc_VoucherSubSection",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubSection_LuserId",
                table: "Acc_VoucherSubSection",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubCheckno_ComId",
                table: "Acc_VoucherSubCheckno",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubCheckno_LuserId",
                table: "Acc_VoucherSubCheckno",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubCheckno_Company_ComId",
                table: "Acc_VoucherSubCheckno",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubCheckno_UserAccount_LuserId",
                table: "Acc_VoucherSubCheckno",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubSection_Company_ComId",
                table: "Acc_VoucherSubSection",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubSection_UserAccount_LuserId",
                table: "Acc_VoucherSubSection",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubCheckno_Company_ComId",
                table: "Acc_VoucherSubCheckno");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubCheckno_UserAccount_LuserId",
                table: "Acc_VoucherSubCheckno");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubSection_Company_ComId",
                table: "Acc_VoucherSubSection");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubSection_UserAccount_LuserId",
                table: "Acc_VoucherSubSection");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSubSection_ComId",
                table: "Acc_VoucherSubSection");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSubSection_LuserId",
                table: "Acc_VoucherSubSection");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSubCheckno_ComId",
                table: "Acc_VoucherSubCheckno");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSubCheckno_LuserId",
                table: "Acc_VoucherSubCheckno");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Acc_VoucherSubSection");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "Acc_VoucherSubSection");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "Acc_VoucherSubSection");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Acc_VoucherSubCheckno");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "Acc_VoucherSubCheckno");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "Acc_VoucherSubCheckno");
        }
    }
}
