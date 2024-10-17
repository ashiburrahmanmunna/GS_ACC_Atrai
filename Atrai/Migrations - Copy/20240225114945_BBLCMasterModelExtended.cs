using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class BBLCMasterModelExtended : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemGroupId",
                table: "BBLCMaster",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_ItemGroupId",
                table: "BBLCMaster",
                column: "ItemGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_ItemGroup_ItemGroupId",
                table: "BBLCMaster",
                column: "ItemGroupId",
                principalTable: "ItemGroup",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_ItemGroup_ItemGroupId",
                table: "BBLCMaster");

            migrationBuilder.DropIndex(
                name: "IX_BBLCMaster_ItemGroupId",
                table: "BBLCMaster");

            migrationBuilder.DropColumn(
                name: "ItemGroupId",
                table: "BBLCMaster");
        }
    }
}
