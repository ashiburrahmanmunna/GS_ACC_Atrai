using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class makerelationinorderallocationoncascad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderAllocationDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderAllocationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    OrderAllocationId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAllocationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderAllocationDetails_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderAllocationDetails_OrderAllocationMaster_OrderAllocationId",
                        column: x => x.OrderAllocationId,
                        principalTable: "OrderAllocationMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderAllocationDetails_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                });

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
        }
    }
}
