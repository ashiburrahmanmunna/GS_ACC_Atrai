using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class salesexchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesExchangeItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CommissionAmount = table.Column<double>(type: "float", nullable: false),
                    CommissionPer = table.Column<double>(type: "float", nullable: false),
                    UserCommissionAmount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SalesExchangeId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    SerialItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostPrice = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesExchangeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesExchangeItems_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesExchangeItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesExchangeItems_SalesReturn_SalesExchangeId",
                        column: x => x.SalesExchangeId,
                        principalTable: "SalesReturn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesExchangeItems_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesExchangeItems_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesExchangeBatchItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesExchangeItemId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PurchaseBatchId = table.Column<int>(type: "int", nullable: false),
                    BatchSerialNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesExchangeBatchItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesExchangeBatchItems_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesExchangeBatchItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesExchangeBatchItems_PurchaseBatchItems_PurchaseBatchId",
                        column: x => x.PurchaseBatchId,
                        principalTable: "PurchaseBatchItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesExchangeBatchItems_SalesExchangeItems_SalesExchangeItemId",
                        column: x => x.SalesExchangeItemId,
                        principalTable: "SalesExchangeItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesExchangeBatchItems_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesExchangeBatchItems_ComId",
                table: "SalesExchangeBatchItems",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesExchangeBatchItems_LuserId",
                table: "SalesExchangeBatchItems",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesExchangeBatchItems_ProductId",
                table: "SalesExchangeBatchItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesExchangeBatchItems_PurchaseBatchId",
                table: "SalesExchangeBatchItems",
                column: "PurchaseBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesExchangeBatchItems_SalesExchangeItemId",
                table: "SalesExchangeBatchItems",
                column: "SalesExchangeItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesExchangeItems_ComId",
                table: "SalesExchangeItems",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesExchangeItems_LuserId",
                table: "SalesExchangeItems",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesExchangeItems_ProductId",
                table: "SalesExchangeItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesExchangeItems_SalesExchangeId",
                table: "SalesExchangeItems",
                column: "SalesExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesExchangeItems_WarehouseId",
                table: "SalesExchangeItems",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesExchangeBatchItems");

            migrationBuilder.DropTable(
                name: "SalesExchangeItems");
        }
    }
}
