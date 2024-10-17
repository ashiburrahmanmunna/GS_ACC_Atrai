using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateShipMode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayListTerm_Company_ComId",
                table: "DayListTerm");

            migrationBuilder.DropForeignKey(
                name: "FK_DayListTerm_UserAccount_LuserId",
                table: "DayListTerm");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipMode_Company_ComId",
                table: "ShipMode");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipMode_UserAccount_LuserId",
                table: "ShipMode");

            migrationBuilder.DropIndex(
                name: "IX_ShipMode_ComId",
                table: "ShipMode");

            migrationBuilder.DropIndex(
                name: "IX_ShipMode_LuserId",
                table: "ShipMode");

            migrationBuilder.DropIndex(
                name: "IX_DayListTerm_ComId",
                table: "DayListTerm");

            migrationBuilder.DropIndex(
                name: "IX_DayListTerm_LuserId",
                table: "DayListTerm");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "ShipMode");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "ShipMode");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "ShipMode");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "DayListTerm");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "DayListTerm");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "DayListTerm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "ShipMode",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "ShipMode",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "ShipMode",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "DayListTerm",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "DayListTerm",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "DayListTerm",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShipMode_ComId",
                table: "ShipMode",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipMode_LuserId",
                table: "ShipMode",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_DayListTerm_ComId",
                table: "DayListTerm",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_DayListTerm_LuserId",
                table: "DayListTerm",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayListTerm_Company_ComId",
                table: "DayListTerm",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayListTerm_UserAccount_LuserId",
                table: "DayListTerm",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipMode_Company_ComId",
                table: "ShipMode",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipMode_UserAccount_LuserId",
                table: "ShipMode",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
