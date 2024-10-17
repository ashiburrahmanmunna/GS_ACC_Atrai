using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class DestrinationModelModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportOrder_Destination_DestinationID",
                table: "ExportOrder");

            migrationBuilder.DropIndex(
                name: "IX_ExportOrder_DestinationID",
                table: "ExportOrder");

            migrationBuilder.DropColumn(
                name: "ExportOrdersId",
                table: "Destination");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExportOrdersId",
                table: "Destination",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportOrder_DestinationID",
                table: "ExportOrder",
                column: "DestinationID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportOrder_Destination_DestinationID",
                table: "ExportOrder",
                column: "DestinationID",
                principalTable: "Destination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
