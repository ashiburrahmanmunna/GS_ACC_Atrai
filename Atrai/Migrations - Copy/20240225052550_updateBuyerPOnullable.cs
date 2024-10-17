using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updateBuyerPOnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_MasterLC_Details_BuyerPO_Master_BuyerPOId",
                table: "COM_MasterLC_Details");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerPOId",
                table: "COM_MasterLC_Details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MasterLC_Details_BuyerPO_Master_BuyerPOId",
                table: "COM_MasterLC_Details",
                column: "BuyerPOId",
                principalTable: "BuyerPO_Master",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_MasterLC_Details_BuyerPO_Master_BuyerPOId",
                table: "COM_MasterLC_Details");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerPOId",
                table: "COM_MasterLC_Details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MasterLC_Details_BuyerPO_Master_BuyerPOId",
                table: "COM_MasterLC_Details",
                column: "BuyerPOId",
                principalTable: "BuyerPO_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
