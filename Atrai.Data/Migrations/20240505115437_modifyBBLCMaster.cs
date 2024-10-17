using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class modifyBBLCMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LCTypeId",
                table: "COM_BBLC_Master",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_COM_BBLC_Master_LCTypeId",
                table: "COM_BBLC_Master",
                column: "LCTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_LCType_LCTypeId",
                table: "COM_BBLC_Master",
                column: "LCTypeId",
                principalTable: "LCType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_LCType_LCTypeId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropIndex(
                name: "IX_COM_BBLC_Master_LCTypeId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropColumn(
                name: "LCTypeId",
                table: "COM_BBLC_Master");
        }
    }
}
