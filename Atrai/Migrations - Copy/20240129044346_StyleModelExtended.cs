using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class StyleModelExtended : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderAllocationMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleId = table.Column<int>(type: "int", nullable: true),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    BuyersId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAllocationMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderAllocationMaster_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderAllocationMaster_Customer_BuyersId",
                        column: x => x.BuyersId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderAllocationMaster_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderAllocationMaster_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderAllocationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderAllocationId = table.Column<int>(type: "int", nullable: true),
                    OrderAllocationMasterId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    ColorsId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    SizesId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_OrderAllocationDetails_Colors_ColorsId",
                        column: x => x.ColorsId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderAllocationDetails_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderAllocationDetails_OrderAllocationMaster_OrderAllocationMasterId",
                        column: x => x.OrderAllocationMasterId,
                        principalTable: "OrderAllocationMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderAllocationDetails_Sizes_SizesId",
                        column: x => x.SizesId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderAllocationDetails_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_ColorsId",
                table: "OrderAllocationDetails",
                column: "ColorsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_ComId",
                table: "OrderAllocationDetails",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_LuserId",
                table: "OrderAllocationDetails",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_OrderAllocationMasterId",
                table: "OrderAllocationDetails",
                column: "OrderAllocationMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_SizesId",
                table: "OrderAllocationDetails",
                column: "SizesId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationMaster_BuyersId",
                table: "OrderAllocationMaster",
                column: "BuyersId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationMaster_ComId",
                table: "OrderAllocationMaster",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationMaster_LuserId",
                table: "OrderAllocationMaster",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationMaster_StyleId",
                table: "OrderAllocationMaster",
                column: "StyleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderAllocationDetails");

            migrationBuilder.DropTable(
                name: "OrderAllocationMaster");
        }
    }
}
