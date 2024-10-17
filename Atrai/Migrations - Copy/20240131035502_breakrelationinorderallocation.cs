using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class breakrelationinorderallocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderAllocationDetails_OrderAllocationMaster_OrderAllocationId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderAllocationDetails_OrderAllocationId",
                table: "OrderAllocationDetails");

            migrationBuilder.AddColumn<int>(
                name: "OrderAllocationMasterModelId",
                table: "OrderAllocationDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_OrderAllocationMasterModelId",
                table: "OrderAllocationDetails",
                column: "OrderAllocationMasterModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAllocationDetails_OrderAllocationMaster_OrderAllocationMasterModelId",
                table: "OrderAllocationDetails",
                column: "OrderAllocationMasterModelId",
                principalTable: "OrderAllocationMaster",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderAllocationDetails_OrderAllocationMaster_OrderAllocationMasterModelId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderAllocationDetails_OrderAllocationMasterModelId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropColumn(
                name: "OrderAllocationMasterModelId",
                table: "OrderAllocationDetails");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_OrderAllocationId",
                table: "OrderAllocationDetails",
                column: "OrderAllocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAllocationDetails_OrderAllocationMaster_OrderAllocationId",
                table: "OrderAllocationDetails",
                column: "OrderAllocationId",
                principalTable: "OrderAllocationMaster",
                principalColumn: "Id");
        }
    }
}
