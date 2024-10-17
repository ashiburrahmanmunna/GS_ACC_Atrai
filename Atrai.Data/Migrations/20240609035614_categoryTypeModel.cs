using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class categoryTypeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryType_Company_ComId",
                table: "CategoryType");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryType_UserAccount_LuserId",
                table: "CategoryType");

            migrationBuilder.DropIndex(
                name: "IX_CategoryType_ComId",
                table: "CategoryType");

            migrationBuilder.DropIndex(
                name: "IX_CategoryType_LuserId",
                table: "CategoryType");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "CategoryType");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "CategoryType");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "CategoryType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "CategoryType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "CategoryType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "CategoryType",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryType_ComId",
                table: "CategoryType",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryType_LuserId",
                table: "CategoryType",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryType_Company_ComId",
                table: "CategoryType",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryType_UserAccount_LuserId",
                table: "CategoryType",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
