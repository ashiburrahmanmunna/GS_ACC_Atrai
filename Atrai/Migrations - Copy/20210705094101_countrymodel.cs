using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class countrymodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "StoreSetting");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DialCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryShortName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CultureInfo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrencySymbol = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CurrencyShortName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FlagClass = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_CountryId",
                table: "StoreSetting",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_Country_CountryId",
                table: "StoreSetting",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_Country_CountryId",
                table: "StoreSetting");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_CountryId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "StoreSetting");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "StoreSetting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
