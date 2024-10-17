using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class gallerycomid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "Gallery",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "Gallery",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_ComId",
                table: "Gallery",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_LuserId",
                table: "Gallery",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Company_ComId",
                table: "Gallery",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_UserAccount_LuserId",
                table: "Gallery",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Company_ComId",
                table: "Gallery");

            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_UserAccount_LuserId",
                table: "Gallery");

            migrationBuilder.DropIndex(
                name: "IX_Gallery_ComId",
                table: "Gallery");

            migrationBuilder.DropIndex(
                name: "IX_Gallery_LuserId",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "Gallery");
        }
    }
}
