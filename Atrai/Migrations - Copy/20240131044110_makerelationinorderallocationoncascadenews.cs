using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class makerelationinorderallocationoncascadenews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderAllocationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderAllocationId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_OrderAllocationDetails_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderAllocationDetails_OrderAllocationMaster_OrderAllocationId",
                        column: x => x.OrderAllocationId,
                        principalTable: "OrderAllocationMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderAllocationDetails_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderAllocationDetails_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_ColorId",
                table: "OrderAllocationDetails",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_ComId",
                table: "OrderAllocationDetails",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_LuserId",
                table: "OrderAllocationDetails",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_OrderAllocationId",
                table: "OrderAllocationDetails",
                column: "OrderAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_SizeId",
                table: "OrderAllocationDetails",
                column: "SizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderAllocationDetails");
        }
    }
}
