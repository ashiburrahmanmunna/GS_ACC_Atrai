using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class BBLCModelExtended27feb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShipModeId",
                table: "BBLCMaster",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_ShipModeId",
                table: "BBLCMaster",
                column: "ShipModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_ShipMode_ShipModeId",
                table: "BBLCMaster",
                column: "ShipModeId",
                principalTable: "ShipMode",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_ShipMode_ShipModeId",
                table: "BBLCMaster");

            migrationBuilder.DropIndex(
                name: "IX_BBLCMaster_ShipModeId",
                table: "BBLCMaster");

            migrationBuilder.DropColumn(
                name: "ShipModeId",
                table: "BBLCMaster");
        }
    }
}
