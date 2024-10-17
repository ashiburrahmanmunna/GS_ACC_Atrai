using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updateMasterLC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_LCNature_LCNatureId",
                table: "MasterLC");

            migrationBuilder.AlterColumn<int>(
                name: "LCNatureId",
                table: "MasterLC",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            //migrationBuilder.AddColumn<int>(
            //    name: "BuyerPOId",
            //    table: "COM_MasterLC_Details",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_COM_MasterLC_Details_BuyerPOId",
            //    table: "COM_MasterLC_Details",
            //    column: "BuyerPOId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_COM_MasterLC_Details_BuyerPO_Master_BuyerPOId",
            //    table: "COM_MasterLC_Details",
            //    column: "BuyerPOId",
            //    principalTable: "BuyerPO_Master",
            //    principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_LCNature_LCNatureId",
                table: "MasterLC",
                column: "LCNatureId",
                principalTable: "LCNature",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_MasterLC_Details_BuyerPO_Master_BuyerPOId",
                table: "COM_MasterLC_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_LCNature_LCNatureId",
                table: "MasterLC");

            migrationBuilder.DropIndex(
                name: "IX_COM_MasterLC_Details_BuyerPOId",
                table: "COM_MasterLC_Details");

            migrationBuilder.DropColumn(
                name: "BuyerPOId",
                table: "COM_MasterLC_Details");

            migrationBuilder.AlterColumn<int>(
                name: "LCNatureId",
                table: "MasterLC",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_LCNature_LCNatureId",
                table: "MasterLC",
                column: "LCNatureId",
                principalTable: "LCNature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
