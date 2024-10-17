using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updateMasterLCDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerPOId",
                table: "COM_MasterLC_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_COM_MasterLC_Details_BuyerPOId",
                table: "COM_MasterLC_Details",
                column: "BuyerPOId");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MasterLC_Details_BuyerPO_Master_BuyerPOId",
                table: "COM_MasterLC_Details",
                column: "BuyerPOId",
                principalTable: "BuyerPO_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_MasterLC_Details_BuyerPO_Master_BuyerPOId",
                table: "COM_MasterLC_Details");

            migrationBuilder.DropIndex(
                name: "IX_COM_MasterLC_Details_BuyerPOId",
                table: "COM_MasterLC_Details");

            migrationBuilder.DropColumn(
                name: "BuyerPOId",
                table: "COM_MasterLC_Details");
        }
    }
}
