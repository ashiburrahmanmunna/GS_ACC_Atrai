using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class shortlinkhit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShortLinkHit_Company_ComId",
                table: "ShortLinkHit");

            migrationBuilder.DropForeignKey(
                name: "FK_ShortLinkHit_UserAccount_LuserId",
                table: "ShortLinkHit");

            migrationBuilder.DropIndex(
                name: "IX_ShortLinkHit_ComId",
                table: "ShortLinkHit");

            migrationBuilder.DropIndex(
                name: "IX_ShortLinkHit_LuserId",
                table: "ShortLinkHit");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "ShortLinkHit");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "ShortLinkHit");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "ShortLinkHit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "ShortLinkHit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "ShortLinkHit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "ShortLinkHit",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShortLinkHit_ComId",
                table: "ShortLinkHit",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ShortLinkHit_LuserId",
                table: "ShortLinkHit",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShortLinkHit_Company_ComId",
                table: "ShortLinkHit",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShortLinkHit_UserAccount_LuserId",
                table: "ShortLinkHit",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
