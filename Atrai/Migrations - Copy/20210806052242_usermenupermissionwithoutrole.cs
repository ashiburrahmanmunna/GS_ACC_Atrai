using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class usermenupermissionwithoutrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermission_UserRole_UserRoleId",
                table: "MenuPermission");

            migrationBuilder.DropIndex(
                name: "IX_MenuPermission_UserRoleId",
                table: "MenuPermission");

            migrationBuilder.DropColumn(
                name: "IsCreatePermission",
                table: "MenuPermission");

            migrationBuilder.DropColumn(
                name: "IsDeletePermission",
                table: "MenuPermission");

            migrationBuilder.DropColumn(
                name: "IsUpdatePermission",
                table: "MenuPermission");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "MenuPermission");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCreatePermission",
                table: "MenuPermission",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeletePermission",
                table: "MenuPermission",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdatePermission",
                table: "MenuPermission",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "MenuPermission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermission_UserRoleId",
                table: "MenuPermission",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermission_UserRole_UserRoleId",
                table: "MenuPermission",
                column: "UserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
