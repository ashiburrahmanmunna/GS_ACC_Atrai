using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDynamicReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DynamicReport_Company_ComId",
                table: "DynamicReport");

            migrationBuilder.DropForeignKey(
                name: "FK_DynamicReport_UserAccount_LuserId",
                table: "DynamicReport");

            migrationBuilder.DropIndex(
                name: "IX_DynamicReport_ComId",
                table: "DynamicReport");

            migrationBuilder.DropIndex(
                name: "IX_DynamicReport_LuserId",
                table: "DynamicReport");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "DynamicReport");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "DynamicReport");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "DynamicReport");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "DynamicReport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "DynamicReport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "DynamicReport",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DynamicReport_ComId",
                table: "DynamicReport",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicReport_LuserId",
                table: "DynamicReport",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DynamicReport_Company_ComId",
                table: "DynamicReport",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DynamicReport_UserAccount_LuserId",
                table: "DynamicReport",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
