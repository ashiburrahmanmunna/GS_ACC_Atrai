using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class DocApprovalSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprovalType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApprovalType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ApprovalStage = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocApprovalSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocTypeId = table.Column<int>(type: "int", nullable: true),
                    ApprovalTypeId = table.Column<int>(type: "int", nullable: true),
                    LuserIdEntry = table.Column<int>(type: "int", nullable: false),
                    LuserIdCheck = table.Column<int>(type: "int", nullable: false),
                    LuserIdVerify = table.Column<int>(type: "int", nullable: false),
                    LuserIdApprove = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocApprovalSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocApprovalSetting_ApprovalType_ApprovalTypeId",
                        column: x => x.ApprovalTypeId,
                        principalTable: "ApprovalType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocApprovalSetting_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocApprovalSetting_DocType_DocTypeId",
                        column: x => x.DocTypeId,
                        principalTable: "DocType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocApprovalSetting_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DocApprovalSetting_UserAccount_LuserIdApprove",
                        column: x => x.LuserIdApprove,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DocApprovalSetting_UserAccount_LuserIdCheck",
                        column: x => x.LuserIdCheck,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DocApprovalSetting_UserAccount_LuserIdEntry",
                        column: x => x.LuserIdEntry,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DocApprovalSetting_UserAccount_LuserIdVerify",
                        column: x => x.LuserIdVerify,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocApprovalSetting_ApprovalTypeId",
                table: "DocApprovalSetting",
                column: "ApprovalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocApprovalSetting_ComId",
                table: "DocApprovalSetting",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_DocApprovalSetting_DocTypeId",
                table: "DocApprovalSetting",
                column: "DocTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocApprovalSetting_LuserId",
                table: "DocApprovalSetting",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocApprovalSetting_LuserIdApprove",
                table: "DocApprovalSetting",
                column: "LuserIdApprove");

            migrationBuilder.CreateIndex(
                name: "IX_DocApprovalSetting_LuserIdCheck",
                table: "DocApprovalSetting",
                column: "LuserIdCheck");

            migrationBuilder.CreateIndex(
                name: "IX_DocApprovalSetting_LuserIdEntry",
                table: "DocApprovalSetting",
                column: "LuserIdEntry");

            migrationBuilder.CreateIndex(
                name: "IX_DocApprovalSetting_LuserIdVerify",
                table: "DocApprovalSetting",
                column: "LuserIdVerify");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocApprovalSetting");

            migrationBuilder.DropTable(
                name: "ApprovalType");
        }
    }
}
