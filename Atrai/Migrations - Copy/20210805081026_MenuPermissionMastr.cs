using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class MenuPermissionMastr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuPermission_Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LUserIdPermission = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPermission_Master", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuPermission_Master_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuPermission_Master_UserAccount_LUserIdPermission",
                        column: x => x.LUserIdPermission,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuPermission_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuPermissionId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    IsCreate = table.Column<bool>(type: "bit", nullable: false),
                    IsEdit = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsView = table.Column<bool>(type: "bit", nullable: false),
                    IsReport = table.Column<bool>(type: "bit", nullable: false),
                    SLNo = table.Column<int>(type: "int", nullable: false),
                    isDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPermission_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuPermission_Details_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuPermission_Details_MenuPermission_Master_MenuPermissionId",
                        column: x => x.MenuPermissionId,
                        principalTable: "MenuPermission_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermission_Details_MenuId",
                table: "MenuPermission_Details",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermission_Details_MenuPermissionId",
                table: "MenuPermission_Details",
                column: "MenuPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermission_Master_ComId",
                table: "MenuPermission_Master",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermission_Master_LUserIdPermission",
                table: "MenuPermission_Master",
                column: "LUserIdPermission");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuPermission_Details");

            migrationBuilder.DropTable(
                name: "MenuPermission_Master");
        }
    }
}
