using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class androidmenupermissionupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AndroidMenuPermission_Menu_AndroidMenuId",
                table: "AndroidMenuPermission");

            migrationBuilder.AddForeignKey(
                name: "FK_AndroidMenuPermission_AndroidMenu_AndroidMenuId",
                table: "AndroidMenuPermission",
                column: "AndroidMenuId",
                principalTable: "AndroidMenu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AndroidMenuPermission_AndroidMenu_AndroidMenuId",
                table: "AndroidMenuPermission");

            migrationBuilder.AddForeignKey(
                name: "FK_AndroidMenuPermission_Menu_AndroidMenuId",
                table: "AndroidMenuPermission",
                column: "AndroidMenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
