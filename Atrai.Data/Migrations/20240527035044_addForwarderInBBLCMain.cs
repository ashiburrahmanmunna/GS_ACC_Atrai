using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class addForwarderInBBLCMain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ForwarderId",
                table: "COM_BBLC_Master",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_COM_BBLC_Master_ForwarderId",
                table: "COM_BBLC_Master",
                column: "ForwarderId");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_Supplier_ForwarderId",
                table: "COM_BBLC_Master",
                column: "ForwarderId",
                principalTable: "Supplier",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_Supplier_ForwarderId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropIndex(
                name: "IX_COM_BBLC_Master_ForwarderId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropColumn(
                name: "ForwarderId",
                table: "COM_BBLC_Master");
        }
    }
}
