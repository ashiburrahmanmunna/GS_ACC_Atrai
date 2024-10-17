using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class userterminatemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternetUser_InternetUserStatus_UserStatusId",
                table: "InternetUser");

            migrationBuilder.DropIndex(
                name: "IX_InternetUser_UserStatusId",
                table: "InternetUser");

            migrationBuilder.AddColumn<int>(
                name: "User Status",
                table: "InternetUser",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExpireDateExtend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternetUserId = table.Column<int>(type: "int", nullable: true),
                    OldExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TotalDays = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpireDateExtend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpireDateExtend_InternetUser_InternetUserId",
                        column: x => x.InternetUserId,
                        principalTable: "InternetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTerminate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternetUserId = table.Column<int>(type: "int", nullable: true),
                    NewExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTerminate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTerminate_InternetUser_InternetUserId",
                        column: x => x.InternetUserId,
                        principalTable: "InternetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternetUser_User Status",
                table: "InternetUser",
                column: "User Status");

            migrationBuilder.CreateIndex(
                name: "IX_ExpireDateExtend_InternetUserId",
                table: "ExpireDateExtend",
                column: "InternetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTerminate_InternetUserId",
                table: "UserTerminate",
                column: "InternetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InternetUser_InternetUserStatus_User Status",
                table: "InternetUser",
                column: "User Status",
                principalTable: "InternetUserStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternetUser_InternetUserStatus_User Status",
                table: "InternetUser");

            migrationBuilder.DropTable(
                name: "ExpireDateExtend");

            migrationBuilder.DropTable(
                name: "UserTerminate");

            migrationBuilder.DropIndex(
                name: "IX_InternetUser_User Status",
                table: "InternetUser");

            migrationBuilder.DropColumn(
                name: "User Status",
                table: "InternetUser");

            migrationBuilder.CreateIndex(
                name: "IX_InternetUser_UserStatusId",
                table: "InternetUser",
                column: "UserStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_InternetUser_InternetUserStatus_UserStatusId",
                table: "InternetUser",
                column: "UserStatusId",
                principalTable: "InternetUserStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
