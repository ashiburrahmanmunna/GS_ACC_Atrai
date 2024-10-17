using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class variableChangedToSelfModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variable_Company_ComId",
                table: "Variable");

            migrationBuilder.DropForeignKey(
                name: "FK_Variable_UserAccount_LuserId",
                table: "Variable");

            migrationBuilder.DropIndex(
                name: "IX_Variable_ComId",
                table: "Variable");

            migrationBuilder.DropIndex(
                name: "IX_Variable_LuserId",
                table: "Variable");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Variable");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "Variable");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "Variable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "Variable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "Variable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "Variable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Variable_ComId",
                table: "Variable",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Variable_LuserId",
                table: "Variable",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Variable_Company_ComId",
                table: "Variable",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Variable_UserAccount_LuserId",
                table: "Variable",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
