using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class batchitemsmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "BatchStartFrom",
                table: "PurchaseItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatchToFrom",
                table: "PurchaseItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrandName",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OldPrice",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ProductSecoundaryUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SecUnitRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSecoundaryUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSecoundaryUnit_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSecoundaryUnit_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseBatchItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchseItemId = table.Column<int>(type: "int", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SecUnitRemarks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseBatchItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseBatchItems_PurchaseItems_PurchseItemId",
                        column: x => x.PurchseItemId,
                        principalTable: "PurchaseItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSecoundaryUnit_ProductId",
                table: "ProductSecoundaryUnit",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSecoundaryUnit_UnitId",
                table: "ProductSecoundaryUnit",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseBatchItems_PurchseItemId",
                table: "PurchaseBatchItems",
                column: "PurchseItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSecoundaryUnit");

            migrationBuilder.DropTable(
                name: "PurchaseBatchItems");

            migrationBuilder.DropColumn(
                name: "BatchStartFrom",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "BatchToFrom",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "BrandName",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OldPrice",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
