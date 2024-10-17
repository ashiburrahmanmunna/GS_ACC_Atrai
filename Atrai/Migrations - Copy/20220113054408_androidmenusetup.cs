using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class androidmenusetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AndroidMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MenuPage = table.Column<int>(type: "int", nullable: false),
                    MenuCaption = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ColorOne = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ColorTwo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ColorThree = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    GradiantStyle = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IconName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IconPath = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    FontColor = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    MenuRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AndroidMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AndroidMenuPermission_Master",
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
                    table.PrimaryKey("PK_AndroidMenuPermission_Master", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AndroidMenuPermission_Master_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AndroidMenuPermission_Master_UserAccount_LUserIdPermission",
                        column: x => x.LUserIdPermission,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AndroidMenuPermission_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AndroidMenuPermissionId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    IsCreate = table.Column<bool>(type: "bit", nullable: false),
                    IsEdit = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteP = table.Column<bool>(type: "bit", nullable: false),
                    IsView = table.Column<bool>(type: "bit", nullable: false),
                    IsReport = table.Column<bool>(type: "bit", nullable: false),
                    SLNo = table.Column<int>(type: "int", nullable: false),
                    isDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AndroidMenuPermission_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AndroidMenuPermission_Details_AndroidMenuPermission_Master_AndroidMenuPermissionId",
                        column: x => x.AndroidMenuPermissionId,
                        principalTable: "AndroidMenuPermission_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AndroidMenuPermission_Details_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AndroidMenuPermission_Details_AndroidMenuPermissionId",
                table: "AndroidMenuPermission_Details",
                column: "AndroidMenuPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AndroidMenuPermission_Details_MenuId",
                table: "AndroidMenuPermission_Details",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_AndroidMenuPermission_Master_ComId",
                table: "AndroidMenuPermission_Master",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_AndroidMenuPermission_Master_LUserIdPermission",
                table: "AndroidMenuPermission_Master",
                column: "LUserIdPermission");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AndroidMenu");

            migrationBuilder.DropTable(
                name: "AndroidMenuPermission_Details");

            migrationBuilder.DropTable(
                name: "AndroidMenuPermission_Master");
        }
    }
}
