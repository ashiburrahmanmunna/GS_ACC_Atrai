using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class CurrencyInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyRate",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "LogoPlacement",
                table: "ReportStyle",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextPlacement",
                table: "ReportStyle",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DailyCurrencyRate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tranDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryIdForeign = table.Column<int>(type: "int", nullable: false),
                    AmountForeign = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CountryIdLocal = table.Column<int>(type: "int", nullable: false),
                    AmountLocalBuy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountLocalSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isAutoEntry = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyCurrencyRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyCurrencyRate_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyCurrencyRate_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CurrencyId",
                table: "Sales",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyCurrencyRate_ComId",
                table: "DailyCurrencyRate",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyCurrencyRate_LuserId",
                table: "DailyCurrencyRate",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Country_CurrencyId",
                table: "Sales",
                column: "CurrencyId",
                principalTable: "Country",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Country_CurrencyId",
                table: "Sales");

            migrationBuilder.DropTable(
                name: "DailyCurrencyRate");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CurrencyId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CurrencyRate",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "LogoPlacement",
                table: "ReportStyle");

            migrationBuilder.DropColumn(
                name: "TextPlacement",
                table: "ReportStyle");
        }
    }
}
