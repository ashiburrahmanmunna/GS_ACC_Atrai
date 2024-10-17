using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class businesstypemenupermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "UserAccount",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusinessTypeId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusinessTypeId",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BusinessType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessTypeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BusinessTypeRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MenuClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDashboard = table.Column<bool>(type: "bit", nullable: false),
                    isParent = table.Column<bool>(type: "bit", nullable: false),
                    MenuGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Menu_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RoleRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuPermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleId = table.Column<int>(type: "int", nullable: true),
                    MenuId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuPermission_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuPermission_UserRole_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_UserRoleId",
                table: "UserAccount",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_BusinessTypeId",
                table: "StoreSetting",
                column: "BusinessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_BusinessTypeId",
                table: "Company",
                column: "BusinessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ParentId",
                table: "Menu",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermission_MenuId",
                table: "MenuPermission",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermission_UserRoleId",
                table: "MenuPermission",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_BusinessType_BusinessTypeId",
                table: "Company",
                column: "BusinessTypeId",
                principalTable: "BusinessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_BusinessType_BusinessTypeId",
                table: "StoreSetting",
                column: "BusinessTypeId",
                principalTable: "BusinessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_UserRole_UserRoleId",
                table: "UserAccount",
                column: "UserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_BusinessType_BusinessTypeId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_BusinessType_BusinessTypeId",
                table: "StoreSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_UserRole_UserRoleId",
                table: "UserAccount");

            migrationBuilder.DropTable(
                name: "BusinessType");

            migrationBuilder.DropTable(
                name: "MenuPermission");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserAccount_UserRoleId",
                table: "UserAccount");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_BusinessTypeId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_Company_BusinessTypeId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "BusinessTypeId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "BusinessTypeId",
                table: "Company");
        }
    }
}
