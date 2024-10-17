using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class makerelationinorderallocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderAllocationDetails_Company_ComId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderAllocationDetails_OrderAllocationMaster_OrderAllocationMasterModelId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderAllocationDetails_UserAccount_LuserId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderAllocationDetails_ComId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderAllocationDetails_LuserId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderAllocationDetails_OrderAllocationMasterModelId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderAllocationDetails_OrderAllocationMaster_OrderAllocationId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderAllocationDetails_OrderAllocationId",
                table: "OrderAllocationDetails");

            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "OrderAllocationDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "OrderAllocationDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "OrderAllocationDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderAllocationMasterModelId",
                table: "OrderAllocationDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_ComId",
                table: "OrderAllocationDetails",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_LuserId",
                table: "OrderAllocationDetails",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_OrderAllocationMasterModelId",
                table: "OrderAllocationDetails",
                column: "OrderAllocationMasterModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAllocationDetails_Company_ComId",
                table: "OrderAllocationDetails",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAllocationDetails_OrderAllocationMaster_OrderAllocationMasterModelId",
                table: "OrderAllocationDetails",
                column: "OrderAllocationMasterModelId",
                principalTable: "OrderAllocationMaster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAllocationDetails_UserAccount_LuserId",
                table: "OrderAllocationDetails",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
