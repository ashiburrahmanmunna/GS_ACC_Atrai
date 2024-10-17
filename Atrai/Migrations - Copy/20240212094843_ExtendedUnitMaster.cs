using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUnitMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExportOrdersId",
                table: "UnitMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitMasterId",
                table: "ExportOrder",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportOrder_UnitMasterId",
                table: "ExportOrder",
                column: "UnitMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportOrder_UnitMaster_UnitMasterId",
                table: "ExportOrder",
                column: "UnitMasterId",
                principalTable: "UnitMaster",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportOrder_UnitMaster_UnitMasterId",
                table: "ExportOrder");

            migrationBuilder.DropIndex(
                name: "IX_ExportOrder_UnitMasterId",
                table: "ExportOrder");

            migrationBuilder.DropColumn(
                name: "ExportOrdersId",
                table: "UnitMaster");

            migrationBuilder.DropColumn(
                name: "UnitMasterId",
                table: "ExportOrder");
        }
    }
}
