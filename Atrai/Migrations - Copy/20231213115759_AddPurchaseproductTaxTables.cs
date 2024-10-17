using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class AddPurchaseproductTaxTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseProductTax",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseProductTax", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseProductTax_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseProductTax_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseProductTax_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProductTax_ComId",
                table: "PurchaseProductTax",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProductTax_LuserId",
                table: "PurchaseProductTax",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProductTax_PurchaseId",
                table: "PurchaseProductTax",
                column: "PurchaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseProductTax");
        }
    }
}
