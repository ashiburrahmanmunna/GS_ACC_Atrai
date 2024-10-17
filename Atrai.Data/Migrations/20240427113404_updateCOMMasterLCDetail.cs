using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateCOMMasterLCDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_MasterLC_Details_UnitMaster_UnitMasterId",
                table: "COM_MasterLC_Details");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MasterLC_Details_Unit_UnitMasterId",
                table: "COM_MasterLC_Details",
                column: "UnitMasterId",
                principalTable: "Unit",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_MasterLC_Details_Unit_UnitMasterId",
                table: "COM_MasterLC_Details");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MasterLC_Details_UnitMaster_UnitMasterId",
                table: "COM_MasterLC_Details",
                column: "UnitMasterId",
                principalTable: "UnitMaster",
                principalColumn: "Id");
        }
    }
}
