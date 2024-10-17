using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class ShippingCharge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInActive",
                table: "Supplier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "SupplierCommissionPer",
                table: "Supplier",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TradeLicenseNo",
                table: "Supplier",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OfferType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferRangeStart = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OfferRangeEnd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OfferFigure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offer_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offer_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ShippingCharge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingLocationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChargeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingCharge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingCharge_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShippingCharge_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offer_ComId",
                table: "Offer",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_LuserId",
                table: "Offer",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingCharge_ComId",
                table: "ShippingCharge",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingCharge_LuserId",
                table: "ShippingCharge",
                column: "LuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "ShippingCharge");

            migrationBuilder.DropColumn(
                name: "IsInActive",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "SupplierCommissionPer",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "TradeLicenseNo",
                table: "Supplier");
        }
    }
}
