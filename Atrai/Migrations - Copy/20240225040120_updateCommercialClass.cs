using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updateCommercialClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupLC_Sub_MasterLC_MasterLCModelId",
                table: "GroupLC_Sub");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_MasterLC_MasterLCModelId",
                table: "MasterLC");

            migrationBuilder.RenameColumn(
                name: "MasterLCModelId",
                table: "MasterLC",
                newName: "TradeTermId");

            migrationBuilder.RenameIndex(
                name: "IX_MasterLC_MasterLCModelId",
                table: "MasterLC",
                newName: "IX_MasterLC_TradeTermId");

            migrationBuilder.RenameColumn(
                name: "MasterLCModelId",
                table: "GroupLC_Sub",
                newName: "MasterLCID");

            migrationBuilder.RenameIndex(
                name: "IX_GroupLC_Sub_MasterLCModelId",
                table: "GroupLC_Sub",
                newName: "IX_GroupLC_Sub_MasterLCID");

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "MasterLC",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShipModeId",
                table: "MasterLC",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_DestinationId",
                table: "MasterLC",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_ShipModeId",
                table: "MasterLC",
                column: "ShipModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Sub_MasterLC_MasterLCID",
                table: "GroupLC_Sub",
                column: "MasterLCID",
                principalTable: "MasterLC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_Destination_DestinationId",
                table: "MasterLC",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_ShipMode_ShipModeId",
                table: "MasterLC",
                column: "ShipModeId",
                principalTable: "ShipMode",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_TradeTerm_TradeTermId",
                table: "MasterLC",
                column: "TradeTermId",
                principalTable: "TradeTerm",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupLC_Sub_MasterLC_MasterLCID",
                table: "GroupLC_Sub");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_Destination_DestinationId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_ShipMode_ShipModeId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_TradeTerm_TradeTermId",
                table: "MasterLC");

            migrationBuilder.DropIndex(
                name: "IX_MasterLC_DestinationId",
                table: "MasterLC");

            migrationBuilder.DropIndex(
                name: "IX_MasterLC_ShipModeId",
                table: "MasterLC");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "MasterLC");

            migrationBuilder.DropColumn(
                name: "ShipModeId",
                table: "MasterLC");

            migrationBuilder.RenameColumn(
                name: "TradeTermId",
                table: "MasterLC",
                newName: "MasterLCModelId");

            migrationBuilder.RenameIndex(
                name: "IX_MasterLC_TradeTermId",
                table: "MasterLC",
                newName: "IX_MasterLC_MasterLCModelId");

            migrationBuilder.RenameColumn(
                name: "MasterLCID",
                table: "GroupLC_Sub",
                newName: "MasterLCModelId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupLC_Sub_MasterLCID",
                table: "GroupLC_Sub",
                newName: "IX_GroupLC_Sub_MasterLCModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Sub_MasterLC_MasterLCModelId",
                table: "GroupLC_Sub",
                column: "MasterLCModelId",
                principalTable: "MasterLC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_MasterLC_MasterLCModelId",
                table: "MasterLC",
                column: "MasterLCModelId",
                principalTable: "MasterLC",
                principalColumn: "Id");
        }
    }
}
