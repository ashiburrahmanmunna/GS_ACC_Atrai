using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class deliveryservicecomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryServiceComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentToLuserId = table.Column<int>(type: "int", nullable: true),
                    DeliveryServiceId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DeliveryServiceModelId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryServiceComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryServiceComment_DeliveryService_DeliveryServiceModelId",
                        column: x => x.DeliveryServiceModelId,
                        principalTable: "DeliveryService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryServiceComment_DeliveryServiceComment_DeliveryServiceId",
                        column: x => x.DeliveryServiceId,
                        principalTable: "DeliveryServiceComment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryServiceComment_UserAccount_CommentToLuserId",
                        column: x => x.CommentToLuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryServiceComment_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TroubleTicket_ComId_TicketNo",
                table: "TroubleTicket",
                columns: new[] { "ComId", "TicketNo" },
                unique: true,
                filter: "[TicketNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ActivationTicket_ComId_TicketNo",
                table: "ActivationTicket",
                columns: new[] { "ComId", "TicketNo" },
                unique: true,
                filter: "[TicketNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryServiceComment_CommentToLuserId",
                table: "DeliveryServiceComment",
                column: "CommentToLuserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryServiceComment_DeliveryServiceId",
                table: "DeliveryServiceComment",
                column: "DeliveryServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryServiceComment_DeliveryServiceModelId",
                table: "DeliveryServiceComment",
                column: "DeliveryServiceModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryServiceComment_LuserId",
                table: "DeliveryServiceComment",
                column: "LuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryServiceComment");

            migrationBuilder.DropIndex(
                name: "IX_TroubleTicket_ComId_TicketNo",
                table: "TroubleTicket");

            migrationBuilder.DropIndex(
                name: "IX_ActivationTicket_ComId_TicketNo",
                table: "ActivationTicket");
        }
    }
}
