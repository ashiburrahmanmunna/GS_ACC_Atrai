using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class forSalesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TokenSalesModelId",
                table: "SalesItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TokenSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseIdMain = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TokenCode = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    TokenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PrimaryAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BlackProductId = table.Column<int>(type: "int", nullable: true),
                    WhiteProductId = table.Column<int>(type: "int", nullable: true),
                    OtherOneProductId = table.Column<int>(type: "int", nullable: true),
                    OtherTwoProductId = table.Column<int>(type: "int", nullable: true),
                    BlackGross = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    WhiteGross = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OtherOneGross = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OtherTwoGross = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    BlackTare = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    WhiteTare = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OtherOneTare = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OtherTwoTare = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    BlackNet = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    WhiteNet = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OtherOneNet = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OtherTwoNet = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    isPosted = table.Column<bool>(type: "bit", nullable: false),
                    DocTypeId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TokenSales_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TokenSales_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TokenSales_DocType_DocTypeId",
                        column: x => x.DocTypeId,
                        principalTable: "DocType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TokenSales_Product_BlackProductId",
                        column: x => x.BlackProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TokenSales_Product_OtherOneProductId",
                        column: x => x.OtherOneProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TokenSales_Product_OtherTwoProductId",
                        column: x => x.OtherTwoProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TokenSales_Product_WhiteProductId",
                        column: x => x.WhiteProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TokenSales_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TokenSales_Warehouse_WarehouseIdMain",
                        column: x => x.WarehouseIdMain,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_TokenSalesModelId",
                table: "SalesItems",
                column: "TokenSalesModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TokenSales_BlackProductId",
                table: "TokenSales",
                column: "BlackProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TokenSales_ComId_TokenCode",
                table: "TokenSales",
                columns: new[] { "ComId", "TokenCode" },
                unique: true,
                filter: "[TokenCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TokenSales_CustomerId",
                table: "TokenSales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TokenSales_DocTypeId",
                table: "TokenSales",
                column: "DocTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TokenSales_LuserId",
                table: "TokenSales",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_TokenSales_OtherOneProductId",
                table: "TokenSales",
                column: "OtherOneProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TokenSales_OtherTwoProductId",
                table: "TokenSales",
                column: "OtherTwoProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TokenSales_WarehouseIdMain",
                table: "TokenSales",
                column: "WarehouseIdMain");

            migrationBuilder.CreateIndex(
                name: "IX_TokenSales_WhiteProductId",
                table: "TokenSales",
                column: "WhiteProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesItems_TokenSales_TokenSalesModelId",
                table: "SalesItems",
                column: "TokenSalesModelId",
                principalTable: "TokenSales",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesItems_TokenSales_TokenSalesModelId",
                table: "SalesItems");

            migrationBuilder.DropTable(
                name: "TokenSales");

            migrationBuilder.DropIndex(
                name: "IX_SalesItems_TokenSalesModelId",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "TokenSalesModelId",
                table: "SalesItems");
        }
    }
}
