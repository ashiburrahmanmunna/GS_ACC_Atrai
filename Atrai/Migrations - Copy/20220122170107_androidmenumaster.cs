using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class androidmenumaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AndroidMenuPermission_Details_Menu_MenuId",
                table: "AndroidMenuPermission_Details");

            migrationBuilder.AddForeignKey(
                name: "FK_AndroidMenuPermission_Details_AndroidMenu_MenuId",
                table: "AndroidMenuPermission_Details",
                column: "MenuId",
                principalTable: "AndroidMenu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AndroidMenuPermission_Details_AndroidMenu_MenuId",
                table: "AndroidMenuPermission_Details");

            migrationBuilder.AddForeignKey(
                name: "FK_AndroidMenuPermission_Details_Menu_MenuId",
                table: "AndroidMenuPermission_Details",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
