using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class useraccountlinkbyid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiagonosisBy",
                table: "TroubleTicket");

            migrationBuilder.DropColumn(
                name: "SupportBy",
                table: "TroubleTicket");

            migrationBuilder.DropColumn(
                name: "Activatedby",
                table: "ActivationTicket");

            migrationBuilder.DropColumn(
                name: "FusionTeamAssaign",
                table: "ActivationTicket");

            migrationBuilder.AddColumn<int>(
                name: "DiagonosisByLUserId",
                table: "TroubleTicket",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupportByLUserId",
                table: "TroubleTicket",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActivatedbyLUserId",
                table: "ActivationTicket",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FusionTeamLUserId",
                table: "ActivationTicket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TroubleTicket_DiagonosisByLUserId",
                table: "TroubleTicket",
                column: "DiagonosisByLUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TroubleTicket_SupportByLUserId",
                table: "TroubleTicket",
                column: "SupportByLUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivationTicket_ActivatedbyLUserId",
                table: "ActivationTicket",
                column: "ActivatedbyLUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivationTicket_FusionTeamLUserId",
                table: "ActivationTicket",
                column: "FusionTeamLUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivationTicket_UserAccount_ActivatedbyLUserId",
                table: "ActivationTicket",
                column: "ActivatedbyLUserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivationTicket_UserAccount_FusionTeamLUserId",
                table: "ActivationTicket",
                column: "FusionTeamLUserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TroubleTicket_UserAccount_DiagonosisByLUserId",
                table: "TroubleTicket",
                column: "DiagonosisByLUserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TroubleTicket_UserAccount_SupportByLUserId",
                table: "TroubleTicket",
                column: "SupportByLUserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivationTicket_UserAccount_ActivatedbyLUserId",
                table: "ActivationTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivationTicket_UserAccount_FusionTeamLUserId",
                table: "ActivationTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_TroubleTicket_UserAccount_DiagonosisByLUserId",
                table: "TroubleTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_TroubleTicket_UserAccount_SupportByLUserId",
                table: "TroubleTicket");

            migrationBuilder.DropIndex(
                name: "IX_TroubleTicket_DiagonosisByLUserId",
                table: "TroubleTicket");

            migrationBuilder.DropIndex(
                name: "IX_TroubleTicket_SupportByLUserId",
                table: "TroubleTicket");

            migrationBuilder.DropIndex(
                name: "IX_ActivationTicket_ActivatedbyLUserId",
                table: "ActivationTicket");

            migrationBuilder.DropIndex(
                name: "IX_ActivationTicket_FusionTeamLUserId",
                table: "ActivationTicket");

            migrationBuilder.DropColumn(
                name: "DiagonosisByLUserId",
                table: "TroubleTicket");

            migrationBuilder.DropColumn(
                name: "SupportByLUserId",
                table: "TroubleTicket");

            migrationBuilder.DropColumn(
                name: "ActivatedbyLUserId",
                table: "ActivationTicket");

            migrationBuilder.DropColumn(
                name: "FusionTeamLUserId",
                table: "ActivationTicket");

            migrationBuilder.AddColumn<string>(
                name: "DiagonosisBy",
                table: "TroubleTicket",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupportBy",
                table: "TroubleTicket",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Activatedby",
                table: "ActivationTicket",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FusionTeamAssaign",
                table: "ActivationTicket",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
