using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedBankAccountNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupLC_Sub_MasterLC_MasterLCID",
                table: "GroupLC_Sub");

            migrationBuilder.DropColumn(
                name: "GroupLC_SubId",
                table: "GroupLC_Main");

            migrationBuilder.RenameColumn(
                name: "MasterLCID",
                table: "GroupLC_Sub",
                newName: "MasterLCModelId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupLC_Sub_MasterLCID",
                table: "GroupLC_Sub",
                newName: "IX_GroupLC_Sub_MasterLCModelId");

            migrationBuilder.AddColumn<int>(
                name: "UnitMasterId1",
                table: "MasterLC",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "unitId",
                table: "MasterLC",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_UnitMasterId1",
                table: "MasterLC",
                column: "UnitMasterId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Sub_MasterLC_MasterLCModelId",
                table: "GroupLC_Sub",
                column: "MasterLCModelId",
                principalTable: "MasterLC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_UnitMaster_UnitMasterId1",
                table: "MasterLC",
                column: "UnitMasterId1",
                principalTable: "UnitMaster",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupLC_Sub_MasterLC_MasterLCModelId",
                table: "GroupLC_Sub");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_UnitMaster_UnitMasterId1",
                table: "MasterLC");

            migrationBuilder.DropIndex(
                name: "IX_MasterLC_UnitMasterId1",
                table: "MasterLC");

            migrationBuilder.DropColumn(
                name: "UnitMasterId1",
                table: "MasterLC");

            migrationBuilder.DropColumn(
                name: "unitId",
                table: "MasterLC");

            migrationBuilder.RenameColumn(
                name: "MasterLCModelId",
                table: "GroupLC_Sub",
                newName: "MasterLCID");

            migrationBuilder.RenameIndex(
                name: "IX_GroupLC_Sub_MasterLCModelId",
                table: "GroupLC_Sub",
                newName: "IX_GroupLC_Sub_MasterLCID");

            migrationBuilder.AddColumn<int>(
                name: "GroupLC_SubId",
                table: "GroupLC_Main",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Sub_MasterLC_MasterLCID",
                table: "GroupLC_Sub",
                column: "MasterLCID",
                principalTable: "MasterLC",
                principalColumn: "Id");
        }
    }
}
