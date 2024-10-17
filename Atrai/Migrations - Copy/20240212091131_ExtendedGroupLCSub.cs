using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedGroupLCSub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasterLCID",
                table: "GroupLC_Sub",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupLC_Sub_MasterLCID",
                table: "GroupLC_Sub",
                column: "MasterLCID");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Sub_MasterLC_MasterLCID",
                table: "GroupLC_Sub",
                column: "MasterLCID",
                principalTable: "MasterLC",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupLC_Sub_MasterLC_MasterLCID",
                table: "GroupLC_Sub");

            migrationBuilder.DropIndex(
                name: "IX_GroupLC_Sub_MasterLCID",
                table: "GroupLC_Sub");

            migrationBuilder.DropColumn(
                name: "MasterLCID",
                table: "GroupLC_Sub");
        }
    }
}
