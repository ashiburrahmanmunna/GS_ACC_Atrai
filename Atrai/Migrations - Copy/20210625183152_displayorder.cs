using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class displayorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermission_Menu_MenuId",
                table: "MenuPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermission_UserRole_UserRoleId",
                table: "MenuPermission");

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleId",
                table: "MenuPermission",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "MenuPermission",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Menu",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermission_Menu_MenuId",
                table: "MenuPermission",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermission_UserRole_UserRoleId",
                table: "MenuPermission",
                column: "UserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermission_Menu_MenuId",
                table: "MenuPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermission_UserRole_UserRoleId",
                table: "MenuPermission");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Menu");

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleId",
                table: "MenuPermission",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "MenuPermission",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermission_Menu_MenuId",
                table: "MenuPermission",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermission_UserRole_UserRoleId",
                table: "MenuPermission",
                column: "UserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
