using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class troubleticketcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TroubleTicketComment_TroubleTicket_TroubleTicketModelId",
                table: "TroubleTicketComment");

            migrationBuilder.DropIndex(
                name: "IX_TroubleTicketComment_TroubleTicketModelId",
                table: "TroubleTicketComment");

            migrationBuilder.DropColumn(
                name: "TroubleTicketModelId",
                table: "TroubleTicketComment");

            migrationBuilder.AddColumn<int>(
                name: "TroubleTicketId",
                table: "TroubleTicketComment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TroubleTicketComment_TroubleTicketId",
                table: "TroubleTicketComment",
                column: "TroubleTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_TroubleTicketComment_TroubleTicket_TroubleTicketId",
                table: "TroubleTicketComment",
                column: "TroubleTicketId",
                principalTable: "TroubleTicket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TroubleTicketComment_TroubleTicket_TroubleTicketId",
                table: "TroubleTicketComment");

            migrationBuilder.DropIndex(
                name: "IX_TroubleTicketComment_TroubleTicketId",
                table: "TroubleTicketComment");

            migrationBuilder.DropColumn(
                name: "TroubleTicketId",
                table: "TroubleTicketComment");

            migrationBuilder.AddColumn<int>(
                name: "TroubleTicketModelId",
                table: "TroubleTicketComment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TroubleTicketComment_TroubleTicketModelId",
                table: "TroubleTicketComment",
                column: "TroubleTicketModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TroubleTicketComment_TroubleTicket_TroubleTicketModelId",
                table: "TroubleTicketComment",
                column: "TroubleTicketModelId",
                principalTable: "TroubleTicket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
