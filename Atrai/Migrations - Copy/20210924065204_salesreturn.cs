using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class salesreturn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalesReturnModelId",
                table: "CostCalculated",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesReturnModelId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SalesReturn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesReturnCode = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
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
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PrimaryAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SecoundaryAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    isPOSSalesReturn = table.Column<bool>(type: "bit", nullable: false),
                    isSerialSalesReturn = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_SalesReturn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesReturn_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesReturn_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesReturn_InternetUser_InternetUserId",
                        column: x => x.InternetUserId,
                        principalTable: "InternetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturn_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesReturnItems",
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
                    SalesReturnId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SalesReturnItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesReturnItems_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesReturnItems_SalesReturn_SalesReturnId",
                        column: x => x.SalesReturnId,
                        principalTable: "SalesReturn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesReturnItems_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnItems_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesReturnPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesReturnId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SalesReturnPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesReturnPayment_AccountHead_AccountHeadId",
                        column: x => x.AccountHeadId,
                        principalTable: "AccountHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnPayment_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnPayment_SalesReturn_SalesReturnId",
                        column: x => x.SalesReturnId,
                        principalTable: "SalesReturn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesReturnPayment_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesReturnBatchItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesReturnItemId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SalesReturnBatchItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesReturnBatchItems_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnBatchItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnBatchItems_PurchaseBatchItems_PurchaseBatchId",
                        column: x => x.PurchaseBatchId,
                        principalTable: "PurchaseBatchItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesReturnBatchItems_SalesReturnItems_SalesReturnItemId",
                        column: x => x.SalesReturnItemId,
                        principalTable: "SalesReturnItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesReturnBatchItems_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_SalesReturnModelId",
                table: "CostCalculated",
                column: "SalesReturnModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_SalesReturnModelId",
                table: "AccountsDailyTransaction",
                column: "SalesReturnModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_ComId_SalesReturnCode",
                table: "SalesReturn",
                columns: new[] { "ComId", "SalesReturnCode" },
                unique: true,
                filter: "[SalesReturnCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_CustomerId",
                table: "SalesReturn",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_InternetUserId",
                table: "SalesReturn",
                column: "InternetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_LuserId",
                table: "SalesReturn",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnBatchItems_ComId",
                table: "SalesReturnBatchItems",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnBatchItems_LuserId",
                table: "SalesReturnBatchItems",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnBatchItems_ProductId",
                table: "SalesReturnBatchItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnBatchItems_PurchaseBatchId",
                table: "SalesReturnBatchItems",
                column: "PurchaseBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnBatchItems_SalesReturnItemId",
                table: "SalesReturnBatchItems",
                column: "SalesReturnItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnItems_ComId",
                table: "SalesReturnItems",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnItems_LuserId",
                table: "SalesReturnItems",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnItems_ProductId",
                table: "SalesReturnItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnItems_SalesReturnId",
                table: "SalesReturnItems",
                column: "SalesReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnItems_WarehouseId",
                table: "SalesReturnItems",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnPayment_AccountHeadId",
                table: "SalesReturnPayment",
                column: "AccountHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnPayment_ComId",
                table: "SalesReturnPayment",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnPayment_LuserId",
                table: "SalesReturnPayment",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnPayment_SalesReturnId",
                table: "SalesReturnPayment",
                column: "SalesReturnId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_SalesReturn_SalesReturnModelId",
                table: "AccountsDailyTransaction",
                column: "SalesReturnModelId",
                principalTable: "SalesReturn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_SalesReturn_SalesReturnModelId",
                table: "CostCalculated",
                column: "SalesReturnModelId",
                principalTable: "SalesReturn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_SalesReturn_SalesReturnModelId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_SalesReturn_SalesReturnModelId",
                table: "CostCalculated");

            migrationBuilder.DropTable(
                name: "SalesReturnBatchItems");

            migrationBuilder.DropTable(
                name: "SalesReturnPayment");

            migrationBuilder.DropTable(
                name: "SalesReturnItems");

            migrationBuilder.DropTable(
                name: "SalesReturn");

            migrationBuilder.DropIndex(
                name: "IX_CostCalculated_SalesReturnModelId",
                table: "CostCalculated");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_SalesReturnModelId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "SalesReturnModelId",
                table: "CostCalculated");

            migrationBuilder.DropColumn(
                name: "SalesReturnModelId",
                table: "AccountsDailyTransaction");
        }
    }
}
