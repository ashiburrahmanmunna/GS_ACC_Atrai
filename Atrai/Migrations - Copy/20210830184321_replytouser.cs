using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class replytouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentToLuserId",
                table: "TroubleTicketComment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TroubleTicketComment_CommentToLuserId",
                table: "TroubleTicketComment",
                column: "CommentToLuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TroubleTicketComment_UserAccount_CommentToLuserId",
                table: "TroubleTicketComment",
                column: "CommentToLuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TroubleTicketComment_UserAccount_CommentToLuserId",
                table: "TroubleTicketComment");

            migrationBuilder.DropIndex(
                name: "IX_TroubleTicketComment_CommentToLuserId",
                table: "TroubleTicketComment");

            migrationBuilder.DropColumn(
                name: "CommentToLuserId",
                table: "TroubleTicketComment");
        }
    }
}
