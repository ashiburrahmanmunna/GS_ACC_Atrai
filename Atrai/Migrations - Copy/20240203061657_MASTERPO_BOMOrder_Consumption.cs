using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class MASTERPO_BOMOrder_Consumption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MASTERPO_BOMOrder_Consumption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterPOId = table.Column<int>(type: "int", nullable: false),
                    BuyerPOId = table.Column<int>(type: "int", nullable: false),
                    BOMMasterId = table.Column<int>(type: "int", nullable: false),
                    Remarks1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remarks2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    BOMAllocationCategoryId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MASTERPO_BOMOrder_Consumption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MASTERPO_BOMOrder_Consumption_BOMAllocationCategory_BOMAllocationCategoryId",
                        column: x => x.BOMAllocationCategoryId,
                        principalTable: "BOMAllocationCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MASTERPO_BOMOrder_Consumption_BOMMaster_BOMMasterId",
                        column: x => x.BOMMasterId,
                        principalTable: "BOMMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MASTERPO_BOMOrder_Consumption_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MASTERPO_BOMOrder_Consumption_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MASTERPO_BOMOrder_Consumption_MasterPO_Master_MasterPOId",
                        column: x => x.MasterPOId,
                        principalTable: "MasterPO_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MASTERPO_BOMOrder_Consumption_OrderAllocationMaster_BuyerPOId",
                        column: x => x.BuyerPOId,
                        principalTable: "OrderAllocationMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MASTERPO_BOMOrder_Consumption_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MASTERPO_BOMOrder_Consumption_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MASTERPO_BOMOrder_Consumption_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_BOMOrder_Consumption_BOMAllocationCategoryId",
                table: "MASTERPO_BOMOrder_Consumption",
                column: "BOMAllocationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_BOMOrder_Consumption_BOMMasterId",
                table: "MASTERPO_BOMOrder_Consumption",
                column: "BOMMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_BOMOrder_Consumption_BuyerPOId",
                table: "MASTERPO_BOMOrder_Consumption",
                column: "BuyerPOId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_BOMOrder_Consumption_ColorId",
                table: "MASTERPO_BOMOrder_Consumption",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_BOMOrder_Consumption_ComId",
                table: "MASTERPO_BOMOrder_Consumption",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_BOMOrder_Consumption_LuserId",
                table: "MASTERPO_BOMOrder_Consumption",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_BOMOrder_Consumption_MasterPOId",
                table: "MASTERPO_BOMOrder_Consumption",
                column: "MasterPOId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_BOMOrder_Consumption_ProductId",
                table: "MASTERPO_BOMOrder_Consumption",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_BOMOrder_Consumption_SizeId",
                table: "MASTERPO_BOMOrder_Consumption",
                column: "SizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MASTERPO_BOMOrder_Consumption");
        }
    }
}
