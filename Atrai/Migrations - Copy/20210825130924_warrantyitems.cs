using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class warrantyitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WarrentyItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplainNo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    PurchaseBatchId = table.Column<int>(type: "int", nullable: true),
                    Complainer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Problem = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SalesId = table.Column<int>(type: "int", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrentyItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarrentyItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarrentyItems_PurchaseBatchItems_PurchaseBatchId",
                        column: x => x.PurchaseBatchId,
                        principalTable: "PurchaseBatchItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarrentyItems_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarrentyItems_ProductId",
                table: "WarrentyItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WarrentyItems_PurchaseBatchId",
                table: "WarrentyItems",
                column: "PurchaseBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_WarrentyItems_SalesId",
                table: "WarrentyItems",
                column: "SalesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarrentyItems");
        }
    }
}
