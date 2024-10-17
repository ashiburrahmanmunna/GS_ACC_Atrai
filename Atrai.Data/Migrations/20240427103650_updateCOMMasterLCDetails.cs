using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateCOMMasterLCDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitMasterId",
                table: "COM_MasterLC_Details",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_COM_MasterLC_Details_UnitMasterId",
                table: "COM_MasterLC_Details",
                column: "UnitMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MasterLC_Details_UnitMaster_UnitMasterId",
                table: "COM_MasterLC_Details",
                column: "UnitMasterId",
                principalTable: "UnitMaster",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_MasterLC_Details_UnitMaster_UnitMasterId",
                table: "COM_MasterLC_Details");

            migrationBuilder.DropIndex(
                name: "IX_COM_MasterLC_Details_UnitMasterId",
                table: "COM_MasterLC_Details");

            migrationBuilder.DropColumn(
                name: "UnitMasterId",
                table: "COM_MasterLC_Details");
        }
    }
}
