using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class businesstypeidchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermission_BusinessType_BusinessTypeid",
                table: "MenuPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_BusinessType_BusinessTypeid",
                table: "UserRole");

            migrationBuilder.RenameColumn(
                name: "BusinessTypeid",
                table: "UserRole",
                newName: "BusinessTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_BusinessTypeid",
                table: "UserRole",
                newName: "IX_UserRole_BusinessTypeId");

            migrationBuilder.RenameColumn(
                name: "BusinessTypeid",
                table: "MenuPermission",
                newName: "BusinessTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuPermission_BusinessTypeid",
                table: "MenuPermission",
                newName: "IX_MenuPermission_BusinessTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermission_BusinessType_BusinessTypeId",
                table: "MenuPermission",
                column: "BusinessTypeId",
                principalTable: "BusinessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_BusinessType_BusinessTypeId",
                table: "UserRole",
                column: "BusinessTypeId",
                principalTable: "BusinessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermission_BusinessType_BusinessTypeId",
                table: "MenuPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_BusinessType_BusinessTypeId",
                table: "UserRole");

            migrationBuilder.RenameColumn(
                name: "BusinessTypeId",
                table: "UserRole",
                newName: "BusinessTypeid");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_BusinessTypeId",
                table: "UserRole",
                newName: "IX_UserRole_BusinessTypeid");

            migrationBuilder.RenameColumn(
                name: "BusinessTypeId",
                table: "MenuPermission",
                newName: "BusinessTypeid");

            migrationBuilder.RenameIndex(
                name: "IX_MenuPermission_BusinessTypeId",
                table: "MenuPermission",
                newName: "IX_MenuPermission_BusinessTypeid");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermission_BusinessType_BusinessTypeid",
                table: "MenuPermission",
                column: "BusinessTypeid",
                principalTable: "BusinessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_BusinessType_BusinessTypeid",
                table: "UserRole",
                column: "BusinessTypeid",
                principalTable: "BusinessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
