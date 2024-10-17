using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class PurchaseItemCategoryModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseItemsCategoryModelId",
                table: "PurchaseBatchItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PurchaseItemsCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    IndDiscount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IndShippingProportion = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    isDisPerRow = table.Column<bool>(type: "bit", nullable: false),
                    SalesUnitPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ProfitPer = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IndDiscountProportion = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItemsCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseItemsCategory_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseItemsCategory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseItemsCategory_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseItemsCategory_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseItemsCategory_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseBatchItems_PurchaseItemsCategoryModelId",
                table: "PurchaseBatchItems",
                column: "PurchaseItemsCategoryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItemsCategory_ComId",
                table: "PurchaseItemsCategory",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItemsCategory_LuserId",
                table: "PurchaseItemsCategory",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItemsCategory_ProductId",
                table: "PurchaseItemsCategory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItemsCategory_PurchaseId",
                table: "PurchaseItemsCategory",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItemsCategory_WarehouseId",
                table: "PurchaseItemsCategory",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseBatchItems_PurchaseItemsCategory_PurchaseItemsCategoryModelId",
                table: "PurchaseBatchItems",
                column: "PurchaseItemsCategoryModelId",
                principalTable: "PurchaseItemsCategory",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseBatchItems_PurchaseItemsCategory_PurchaseItemsCategoryModelId",
                table: "PurchaseBatchItems");

            migrationBuilder.DropTable(
                name: "PurchaseItemsCategory");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseBatchItems_PurchaseItemsCategoryModelId",
                table: "PurchaseBatchItems");

            migrationBuilder.DropColumn(
                name: "PurchaseItemsCategoryModelId",
                table: "PurchaseBatchItems");
        }
    }
}
