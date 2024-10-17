using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class countryidandcurrencyid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "UserAccount");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "StoreSetting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Company",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_CurrencyId",
                table: "StoreSetting",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CurrencyId",
                table: "Company",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Country_CurrencyId",
                table: "Company",
                column: "CurrencyId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_Country_CurrencyId",
                table: "StoreSetting",
                column: "CurrencyId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Country_CurrencyId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_Country_CurrencyId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_CurrencyId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_Company_CurrencyId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Company");

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "UserAccount",
                type: "int",
                nullable: true);
        }
    }
}
