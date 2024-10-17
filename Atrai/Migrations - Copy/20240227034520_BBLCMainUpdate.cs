using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class BBLCMainUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "COM_MasterLCId",
                table: "BBLCMaster",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_COM_MasterLCId",
                table: "BBLCMaster",
                column: "COM_MasterLCId");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_MasterLC_COM_MasterLCId",
                table: "BBLCMaster",
                column: "COM_MasterLCId",
                principalTable: "MasterLC",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_MasterLC_COM_MasterLCId",
                table: "BBLCMaster");

            migrationBuilder.DropIndex(
                name: "IX_BBLCMaster_COM_MasterLCId",
                table: "BBLCMaster");

            migrationBuilder.DropColumn(
                name: "COM_MasterLCId",
                table: "BBLCMaster");
        }
    }
}
