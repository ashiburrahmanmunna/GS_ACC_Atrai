using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class purchasemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    GrandTotal = table.Column<double>(type: "float", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ttlSumQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ttlCountQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ttlUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ttlIndVat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ttlIndDisAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ttlIndPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ttlSumAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecoundaryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isPOSPurchase = table.Column<bool>(type: "bit", nullable: false),
                    isPosted = table.Column<bool>(type: "bit", nullable: false),
                    AccountPayTypeId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_AccountHead_AccountPayTypeId",
                        column: x => x.AccountPayTypeId,
                        principalTable: "AccountHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchase_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchasePayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    PaymentCardNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_PurchasePayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasePayment_AccountHead_AccountHeadId",
                        column: x => x.AccountHeadId,
                        principalTable: "AccountHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchasePayment_PaymentType_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchasePayment_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_AccountPayTypeId",
                table: "Purchase",
                column: "AccountPayTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_SupplierId",
                table: "Purchase",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_ProductId",
                table: "PurchaseItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_PurchaseId",
                table: "PurchaseItems",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_WarehouseId",
                table: "PurchaseItems",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayment_AccountHeadId",
                table: "PurchasePayment",
                column: "AccountHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayment_PaymentTypeId",
                table: "PurchasePayment",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayment_PurchaseId",
                table: "PurchasePayment",
                column: "PurchaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseItems");

            migrationBuilder.DropTable(
                name: "PurchasePayment");

            migrationBuilder.DropTable(
                name: "Purchase");
        }
    }
}
