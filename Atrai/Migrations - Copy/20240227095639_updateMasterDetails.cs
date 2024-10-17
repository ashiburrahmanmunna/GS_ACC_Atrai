using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updateMasterDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_MasterLC_Details_MasterLC_MasterLCID",
                table: "COM_MasterLC_Details");

            migrationBuilder.AlterColumn<int>(
                name: "MasterLCID",
                table: "COM_MasterLC_Details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MasterLC_Details_MasterLC_MasterLCID",
                table: "COM_MasterLC_Details",
                column: "MasterLCID",
                principalTable: "MasterLC",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_MasterLC_Details_MasterLC_MasterLCID",
                table: "COM_MasterLC_Details");

            migrationBuilder.AlterColumn<int>(
                name: "MasterLCID",
                table: "COM_MasterLC_Details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MasterLC_Details_MasterLC_MasterLCID",
                table: "COM_MasterLC_Details",
                column: "MasterLCID",
                principalTable: "MasterLC",
                principalColumn: "Id");
        }
    }
}
