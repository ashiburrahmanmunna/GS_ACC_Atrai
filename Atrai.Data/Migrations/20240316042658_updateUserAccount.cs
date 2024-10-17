using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateUserAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_UserAccount_LuserId",
                table: "UserAccount");

            migrationBuilder.AlterColumn<int>(
                name: "LuserId",
                table: "UserAccount",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_UserAccount_LuserId",
                table: "UserAccount",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_UserAccount_LuserId",
                table: "UserAccount");

            migrationBuilder.AlterColumn<int>(
                name: "LuserId",
                table: "UserAccount",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_UserAccount_LuserId",
                table: "UserAccount",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
