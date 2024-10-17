using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class costcalculated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountPayTypeId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CostCalculated",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    isManualProcess = table.Column<bool>(type: "bit", nullable: false),
                    CurrQty = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CurrPrice = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    TotalCurrPrice = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    PrevQty = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    PrevPrice = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    TotalPrevPrice = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    CalculatedPrice = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    CalculatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDocNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCalculated", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostCalculated_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostCalculated_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostCalculated_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_AccountPayTypeId",
                table: "Sales",
                column: "AccountPayTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_ProductId",
                table: "CostCalculated",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_SalesId",
                table: "CostCalculated",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_WarehouseId",
                table: "CostCalculated",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_AccountHead_AccountPayTypeId",
                table: "Sales",
                column: "AccountPayTypeId",
                principalTable: "AccountHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_AccountHead_AccountPayTypeId",
                table: "Sales");

            migrationBuilder.DropTable(
                name: "CostCalculated");

            migrationBuilder.DropIndex(
                name: "IX_Sales_AccountPayTypeId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "AccountPayTypeId",
                table: "Sales");
        }
    }
}
