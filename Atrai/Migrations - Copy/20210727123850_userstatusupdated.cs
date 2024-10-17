using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class userstatusupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternetUser_InternetUserStatus_User Status",
                table: "InternetUser");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_InternetUser_User Status",
                table: "InternetUser",
                column: "User Status");

            migrationBuilder.AddForeignKey(
                name: "FK_InternetUser_InternetUserStatus_User Status",
                table: "InternetUser",
                column: "User Status",
                principalTable: "InternetUserStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
