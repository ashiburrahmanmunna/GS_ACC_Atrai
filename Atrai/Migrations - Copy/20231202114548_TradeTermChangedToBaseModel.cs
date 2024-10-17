using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class TradeTermChangedToBaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "TradeTerms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "TradeTerms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "TradeTerms",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReminderTwoDays",
                table: "StoreSetting",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ReminderThreeDays",
                table: "StoreSetting",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ReminderOneDays",
                table: "StoreSetting",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TradeTerms_ComId",
                table: "TradeTerms",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeTerms_LuserId",
                table: "TradeTerms",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TradeTerms_Company_ComId",
                table: "TradeTerms",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TradeTerms_UserAccount_LuserId",
                table: "TradeTerms",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TradeTerms_Company_ComId",
                table: "TradeTerms");

            migrationBuilder.DropForeignKey(
                name: "FK_TradeTerms_UserAccount_LuserId",
                table: "TradeTerms");

            migrationBuilder.DropIndex(
                name: "IX_TradeTerms_ComId",
                table: "TradeTerms");

            migrationBuilder.DropIndex(
                name: "IX_TradeTerms_LuserId",
                table: "TradeTerms");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "TradeTerms");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "TradeTerms");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "TradeTerms");

            migrationBuilder.AlterColumn<int>(
                name: "ReminderTwoDays",
                table: "StoreSetting",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReminderThreeDays",
                table: "StoreSetting",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReminderOneDays",
                table: "StoreSetting",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
