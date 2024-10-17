using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class purchasereturn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_SalesReturn_SalesReturnModelId",
                table: "CostCalculated");

            migrationBuilder.RenameColumn(
                name: "SalesReturnModelId",
                table: "CostCalculated",
                newName: "SalesReturnId");

            migrationBuilder.RenameIndex(
                name: "IX_CostCalculated_SalesReturnModelId",
                table: "CostCalculated",
                newName: "IX_CostCalculated_SalesReturnId");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseReturnId",
                table: "CostCalculated",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseReturnModelId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PurchaseReturn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseReturnCode = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCommisionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChkPer = table.Column<bool>(type: "bit", nullable: false),
                    DisPer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DisAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Shipping = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalVat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DueAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PrimaryAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SecoundaryAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    isPOSPurchaseReturn = table.Column<bool>(type: "bit", nullable: false),
                    isSerialPurchaseReturn = table.Column<bool>(type: "bit", nullable: false),
                    isPosted = table.Column<bool>(type: "bit", nullable: false),
                    Profit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProfitPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinalCostingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_PurchaseReturn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseReturn_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturn_InternetUser_InternetUserId",
                        column: x => x.InternetUserId,
                        principalTable: "InternetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturn_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturn_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturnItems",
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
                    PurchaseReturnId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PurchaseReturnItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnItems_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnItems_PurchaseReturn_PurchaseReturnId",
                        column: x => x.PurchaseReturnId,
                        principalTable: "PurchaseReturn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnItems_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnItems_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturnPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseReturnId = table.Column<int>(type: "int", nullable: false),
                    PaymentCardNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    isPosted = table.Column<bool>(type: "bit", nullable: false),
                    AccountHeadId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RowNo = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturnPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnPayment_AccountHead_AccountHeadId",
                        column: x => x.AccountHeadId,
                        principalTable: "AccountHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnPayment_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnPayment_PurchaseReturn_PurchaseReturnId",
                        column: x => x.PurchaseReturnId,
                        principalTable: "PurchaseReturn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnPayment_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturnBatchItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseReturnItemId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PurchaseReturnBatchItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnBatchItems_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnBatchItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnBatchItems_PurchaseBatchItems_PurchaseBatchId",
                        column: x => x.PurchaseBatchId,
                        principalTable: "PurchaseBatchItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnBatchItems_PurchaseReturnItems_PurchaseReturnItemId",
                        column: x => x.PurchaseReturnItemId,
                        principalTable: "PurchaseReturnItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnBatchItems_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_PurchaseReturnId",
                table: "CostCalculated",
                column: "PurchaseReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_PurchaseReturnModelId",
                table: "AccountsDailyTransaction",
                column: "PurchaseReturnModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturn_ComId_PurchaseReturnCode",
                table: "PurchaseReturn",
                columns: new[] { "ComId", "PurchaseReturnCode" },
                unique: true,
                filter: "[PurchaseReturnCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturn_InternetUserId",
                table: "PurchaseReturn",
                column: "InternetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturn_LuserId",
                table: "PurchaseReturn",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturn_SupplierId",
                table: "PurchaseReturn",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnBatchItems_ComId",
                table: "PurchaseReturnBatchItems",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnBatchItems_LuserId",
                table: "PurchaseReturnBatchItems",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnBatchItems_ProductId",
                table: "PurchaseReturnBatchItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnBatchItems_PurchaseBatchId",
                table: "PurchaseReturnBatchItems",
                column: "PurchaseBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnBatchItems_PurchaseReturnItemId",
                table: "PurchaseReturnBatchItems",
                column: "PurchaseReturnItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnItems_ComId",
                table: "PurchaseReturnItems",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnItems_LuserId",
                table: "PurchaseReturnItems",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnItems_ProductId",
                table: "PurchaseReturnItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnItems_PurchaseReturnId",
                table: "PurchaseReturnItems",
                column: "PurchaseReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnItems_WarehouseId",
                table: "PurchaseReturnItems",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnPayment_AccountHeadId",
                table: "PurchaseReturnPayment",
                column: "AccountHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnPayment_ComId",
                table: "PurchaseReturnPayment",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnPayment_LuserId",
                table: "PurchaseReturnPayment",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnPayment_PurchaseReturnId",
                table: "PurchaseReturnPayment",
                column: "PurchaseReturnId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_PurchaseReturn_PurchaseReturnModelId",
                table: "AccountsDailyTransaction",
                column: "PurchaseReturnModelId",
                principalTable: "PurchaseReturn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_PurchaseReturn_PurchaseReturnId",
                table: "CostCalculated",
                column: "PurchaseReturnId",
                principalTable: "PurchaseReturn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_SalesReturn_SalesReturnId",
                table: "CostCalculated",
                column: "SalesReturnId",
                principalTable: "SalesReturn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_PurchaseReturn_PurchaseReturnModelId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_PurchaseReturn_PurchaseReturnId",
                table: "CostCalculated");

            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_SalesReturn_SalesReturnId",
                table: "CostCalculated");

            migrationBuilder.DropTable(
                name: "PurchaseReturnBatchItems");

            migrationBuilder.DropTable(
                name: "PurchaseReturnPayment");

            migrationBuilder.DropTable(
                name: "PurchaseReturnItems");

            migrationBuilder.DropTable(
                name: "PurchaseReturn");

            migrationBuilder.DropIndex(
                name: "IX_CostCalculated_PurchaseReturnId",
                table: "CostCalculated");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_PurchaseReturnModelId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "PurchaseReturnId",
                table: "CostCalculated");

            migrationBuilder.DropColumn(
                name: "PurchaseReturnModelId",
                table: "AccountsDailyTransaction");

            migrationBuilder.RenameColumn(
                name: "SalesReturnId",
                table: "CostCalculated",
                newName: "SalesReturnModelId");

            migrationBuilder.RenameIndex(
                name: "IX_CostCalculated_SalesReturnId",
                table: "CostCalculated",
                newName: "IX_CostCalculated_SalesReturnModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_SalesReturn_SalesReturnModelId",
                table: "CostCalculated",
                column: "SalesReturnModelId",
                principalTable: "SalesReturn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
