using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class BBLCModelExtended27febAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommercialCompanyId",
                table: "BBLCMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupLCId",
                table: "BBLCMaster",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_CommercialCompanyId",
                table: "BBLCMaster",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_GroupLCId",
                table: "BBLCMaster",
                column: "GroupLCId");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_Commercial_CommercialCompanyId",
                table: "BBLCMaster",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_GroupLC_Main_GroupLCId",
                table: "BBLCMaster",
                column: "GroupLCId",
                principalTable: "GroupLC_Main",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_Commercial_CommercialCompanyId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_GroupLC_Main_GroupLCId",
                table: "BBLCMaster");

            migrationBuilder.DropIndex(
                name: "IX_BBLCMaster_CommercialCompanyId",
                table: "BBLCMaster");

            migrationBuilder.DropIndex(
                name: "IX_BBLCMaster_GroupLCId",
                table: "BBLCMaster");

            migrationBuilder.DropColumn(
                name: "CommercialCompanyId",
                table: "BBLCMaster");

            migrationBuilder.DropColumn(
                name: "GroupLCId",
                table: "BBLCMaster");
        }
    }
}
