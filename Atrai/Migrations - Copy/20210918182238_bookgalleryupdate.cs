using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class bookgalleryupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesGallery_Company_ComId",
                table: "ImagesGallery");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagesGallery_UserAccount_LuserId",
                table: "ImagesGallery");

            migrationBuilder.DropIndex(
                name: "IX_ImagesGallery_ComId",
                table: "ImagesGallery");

            migrationBuilder.DropIndex(
                name: "IX_ImagesGallery_LuserId",
                table: "ImagesGallery");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "ImagesGallery");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "ImagesGallery");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "ImagesGallery");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "ImagesGallery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "ImagesGallery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "ImagesGallery",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImagesGallery_ComId",
                table: "ImagesGallery",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesGallery_LuserId",
                table: "ImagesGallery",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesGallery_Company_ComId",
                table: "ImagesGallery",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesGallery_UserAccount_LuserId",
                table: "ImagesGallery",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
