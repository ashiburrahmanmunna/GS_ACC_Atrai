using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class InternalTransfer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InternalTransferModelId",
                table: "CostCalculated",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InternalTransfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternalTransferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InternalTransferCode = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReferanceOne = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReferanceTwo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    isPosted = table.Column<bool>(type: "bit", nullable: false),
                    InternetUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalTransfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalTransfer_InternetUser_InternetUserId",
                        column: x => x.InternetUserId,
                        principalTable: "InternetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InternalTransferItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    InternalTransferId = table.Column<int>(type: "int", nullable: false),
                    FromWarehouseId = table.Column<int>(type: "int", nullable: true),
                    ToWarehouseId = table.Column<int>(type: "int", nullable: true),
                    SerialItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalTransferItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalTransferItems_InternalTransfer_InternalTransferId",
                        column: x => x.InternalTransferId,
                        principalTable: "InternalTransfer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalTransferItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalTransferItems_Warehouse_FromWarehouseId",
                        column: x => x.FromWarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalTransferItems_Warehouse_ToWarehouseId",
                        column: x => x.ToWarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InternalTransferBatchItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternalTransferItemId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_InternalTransferBatchItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalTransferBatchItems_InternalTransferItems_InternalTransferItemId",
                        column: x => x.InternalTransferItemId,
                        principalTable: "InternalTransferItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalTransferBatchItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalTransferBatchItems_PurchaseBatchItems_PurchaseBatchId",
                        column: x => x.PurchaseBatchId,
                        principalTable: "PurchaseBatchItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_InternalTransferModelId",
                table: "CostCalculated",
                column: "InternalTransferModelId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalTransfer_ComId_InternalTransferCode",
                table: "InternalTransfer",
                columns: new[] { "ComId", "InternalTransferCode" },
                unique: true,
                filter: "[InternalTransferCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InternalTransfer_InternetUserId",
                table: "InternalTransfer",
                column: "InternetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalTransferBatchItems_InternalTransferItemId",
                table: "InternalTransferBatchItems",
                column: "InternalTransferItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalTransferBatchItems_ProductId",
                table: "InternalTransferBatchItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalTransferBatchItems_PurchaseBatchId",
                table: "InternalTransferBatchItems",
                column: "PurchaseBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalTransferItems_FromWarehouseId",
                table: "InternalTransferItems",
                column: "FromWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalTransferItems_InternalTransferId",
                table: "InternalTransferItems",
                column: "InternalTransferId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalTransferItems_ProductId",
                table: "InternalTransferItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalTransferItems_ToWarehouseId",
                table: "InternalTransferItems",
                column: "ToWarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_InternalTransfer_InternalTransferModelId",
                table: "CostCalculated",
                column: "InternalTransferModelId",
                principalTable: "InternalTransfer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_InternalTransfer_InternalTransferModelId",
                table: "CostCalculated");

            migrationBuilder.DropTable(
                name: "InternalTransferBatchItems");

            migrationBuilder.DropTable(
                name: "InternalTransferItems");

            migrationBuilder.DropTable(
                name: "InternalTransfer");

            migrationBuilder.DropIndex(
                name: "IX_CostCalculated_InternalTransferModelId",
                table: "CostCalculated");

            migrationBuilder.DropColumn(
                name: "InternalTransferModelId",
                table: "CostCalculated");
        }
    }
}
