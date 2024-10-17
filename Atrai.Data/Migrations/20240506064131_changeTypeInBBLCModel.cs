using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeTypeInBBLCModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_LCType_LCTypeId",
                table: "COM_BBLC_Master");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_CommercialLCType_LCTypeId",
                table: "COM_BBLC_Master",
                column: "LCTypeId",
                principalTable: "CommercialLCType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_CommercialLCType_LCTypeId",
                table: "COM_BBLC_Master");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_LCType_LCTypeId",
                table: "COM_BBLC_Master",
                column: "LCTypeId",
                principalTable: "LCType",
                principalColumn: "Id");
        }
    }
}
