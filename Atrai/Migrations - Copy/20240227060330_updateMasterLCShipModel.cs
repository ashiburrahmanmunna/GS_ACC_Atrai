using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updateMasterLCShipModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_ShipModel_ShipModelId",
                table: "MasterLC");

            migrationBuilder.AlterColumn<int>(
                name: "ShipModelId",
                table: "MasterLC",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_ShipModel_ShipModelId",
                table: "MasterLC",
                column: "ShipModelId",
                principalTable: "ShipModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_ShipModel_ShipModelId",
                table: "MasterLC");

            migrationBuilder.AlterColumn<int>(
                name: "ShipModelId",
                table: "MasterLC",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_ShipModel_ShipModelId",
                table: "MasterLC",
                column: "ShipModelId",
                principalTable: "ShipModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
