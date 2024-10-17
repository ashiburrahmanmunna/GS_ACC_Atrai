using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updateOrderAllocationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderAllocationDetails_Colors_ColorsId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderAllocationDetails_OrderAllocationMaster_OrderAllocationMasterId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderAllocationDetails_Sizes_SizesId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderAllocationMaster_Customer_BuyersId",
                table: "OrderAllocationMaster");

            migrationBuilder.DropIndex(
                name: "IX_OrderAllocationMaster_BuyersId",
                table: "OrderAllocationMaster");

            migrationBuilder.DropIndex(
                name: "IX_OrderAllocationDetails_ColorsId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderAllocationDetails_OrderAllocationMasterId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderAllocationDetails_SizesId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropColumn(
                name: "BuyersId",
                table: "OrderAllocationMaster");

            migrationBuilder.DropColumn(
                name: "ColorsId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropColumn(
                name: "OrderAllocationMasterId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropColumn(
                name: "SizesId",
                table: "OrderAllocationDetails");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationMaster_BuyerId",
                table: "OrderAllocationMaster",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_ColorId",
                table: "OrderAllocationDetails",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_OrderAllocationId",
                table: "OrderAllocationDetails",
                column: "OrderAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_SizeId",
                table: "OrderAllocationDetails",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAllocationDetails_Colors_ColorId",
                table: "OrderAllocationDetails",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAllocationDetails_OrderAllocationMaster_OrderAllocationId",
                table: "OrderAllocationDetails",
                column: "OrderAllocationId",
                principalTable: "OrderAllocationMaster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAllocationDetails_Sizes_SizeId",
                table: "OrderAllocationDetails",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAllocationMaster_Customer_BuyerId",
                table: "OrderAllocationMaster",
                column: "BuyerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderAllocationDetails_Colors_ColorId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderAllocationDetails_OrderAllocationMaster_OrderAllocationId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderAllocationDetails_Sizes_SizeId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderAllocationMaster_Customer_BuyerId",
                table: "OrderAllocationMaster");

            migrationBuilder.DropIndex(
                name: "IX_OrderAllocationMaster_BuyerId",
                table: "OrderAllocationMaster");

            migrationBuilder.DropIndex(
                name: "IX_OrderAllocationDetails_ColorId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderAllocationDetails_OrderAllocationId",
                table: "OrderAllocationDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderAllocationDetails_SizeId",
                table: "OrderAllocationDetails");

            migrationBuilder.AddColumn<int>(
                name: "BuyersId",
                table: "OrderAllocationMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorsId",
                table: "OrderAllocationDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderAllocationMasterId",
                table: "OrderAllocationDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizesId",
                table: "OrderAllocationDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationMaster_BuyersId",
                table: "OrderAllocationMaster",
                column: "BuyersId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_ColorsId",
                table: "OrderAllocationDetails",
                column: "ColorsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_OrderAllocationMasterId",
                table: "OrderAllocationDetails",
                column: "OrderAllocationMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_SizesId",
                table: "OrderAllocationDetails",
                column: "SizesId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAllocationDetails_Colors_ColorsId",
                table: "OrderAllocationDetails",
                column: "ColorsId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAllocationDetails_OrderAllocationMaster_OrderAllocationMasterId",
                table: "OrderAllocationDetails",
                column: "OrderAllocationMasterId",
                principalTable: "OrderAllocationMaster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAllocationDetails_Sizes_SizesId",
                table: "OrderAllocationDetails",
                column: "SizesId",
                principalTable: "Sizes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAllocationMaster_Customer_BuyersId",
                table: "OrderAllocationMaster",
                column: "BuyersId",
                principalTable: "Customer",
                principalColumn: "Id");
        }
    }
}
