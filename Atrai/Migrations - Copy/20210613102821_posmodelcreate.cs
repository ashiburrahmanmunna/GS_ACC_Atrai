using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class posmodelcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "VGM",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "UserAccount",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "StoreSetting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "SalesItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "SalesItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardNo",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ChkPer",
                table: "Sales",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DisAmt",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DisPer",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DueAmt",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "EmailId",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "NetAmount",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PaidAmt",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryAddress",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecoundaryAddress",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ServiceCharge",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Shipping",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalVat",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlCountQty",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlIndDisAmt",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlIndPrice",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlIndVat",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlSumAmt",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlSumQty",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlUnitPrice",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AccountHead",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NumericNumber = table.Column<int>(type: "int", nullable: true),
                    isSystem = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    AccountCategory = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountHead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountHead_AccountHead_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AccountHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypeModel",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TypeShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypeModel", x => x.PaymentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WhName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WhShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WhType = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouse_Warehouse_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountsDailyTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    AccountHeadId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionAmount = table.Column<float>(type: "real", nullable: false),
                    isPost = table.Column<bool>(type: "bit", nullable: false),
                    ReceivedPaymentTypeHeadId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsDailyTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountsDailyTransaction_AccountHead_AccountHeadId",
                        column: x => x.AccountHeadId,
                        principalTable: "AccountHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountsDailyTransaction_AccountHead_ReceivedPaymentTypeHeadId",
                        column: x => x.ReceivedPaymentTypeHeadId,
                        principalTable: "AccountHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesPaymentModel",
                columns: table => new
                {
                    SalesId = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    PaymentCardNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isPosted = table.Column<bool>(type: "bit", nullable: false),
                    AccId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RowNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPaymentModel", x => x.SalesId);
                    table.ForeignKey(
                        name: "FK_SalesPaymentModel_AccountHead_AccId",
                        column: x => x.AccId,
                        principalTable: "AccountHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesPaymentModel_PaymentTypeModel_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypeModel",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesPaymentModel_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_WarehouseId",
                table: "SalesItems",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHead_ParentId",
                table: "AccountHead",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_AccountHeadId",
                table: "AccountsDailyTransaction",
                column: "AccountHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_ReceivedPaymentTypeHeadId",
                table: "AccountsDailyTransaction",
                column: "ReceivedPaymentTypeHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPaymentModel_AccId",
                table: "SalesPaymentModel",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPaymentModel_PaymentTypeId",
                table: "SalesPaymentModel",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_ParentId",
                table: "Warehouse",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesItems_Warehouse_WarehouseId",
                table: "SalesItems",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesItems_Warehouse_WarehouseId",
                table: "SalesItems");

            migrationBuilder.DropTable(
                name: "AccountsDailyTransaction");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "SalesPaymentModel");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "AccountHead");

            migrationBuilder.DropTable(
                name: "PaymentTypeModel");

            migrationBuilder.DropIndex(
                name: "IX_SalesItems_WarehouseId",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "VGM");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "CardNo",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ChkPer",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "DisAmt",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "DisPer",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "DueAmt",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "NetAmount",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "PaidAmt",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "PrimaryAddress",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SecoundaryAddress",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ServiceCharge",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Shipping",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "TotalVat",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ttlCountQty",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ttlIndDisAmt",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ttlIndPrice",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ttlIndVat",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ttlSumAmt",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ttlSumQty",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ttlUnitPrice",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "Customer");
        }
    }
}
