using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class Gatepass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GatePass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GatePassDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GatePassCode = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    StyleNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BuyerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Transport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManualNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Through = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GatePass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GatePass_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GatePass_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GatePassItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    SLNo = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ColorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SizeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    PackageQuantity = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    GatePassId = table.Column<int>(type: "int", nullable: false),
                    IsTransaction = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GatePassItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GatePassItems_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GatePassItems_GatePass_GatePassId",
                        column: x => x.GatePassId,
                        principalTable: "GatePass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GatePassItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GatePassItems_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GatePass_ComId",
                table: "GatePass",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_GatePass_LuserId",
                table: "GatePass",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_GatePassItems_ComId",
                table: "GatePassItems",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_GatePassItems_GatePassId",
                table: "GatePassItems",
                column: "GatePassId");

            migrationBuilder.CreateIndex(
                name: "IX_GatePassItems_LuserId",
                table: "GatePassItems",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_GatePassItems_ProductId",
                table: "GatePassItems",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GatePassItems");

            migrationBuilder.DropTable(
                name: "GatePass");
        }
    }
}
