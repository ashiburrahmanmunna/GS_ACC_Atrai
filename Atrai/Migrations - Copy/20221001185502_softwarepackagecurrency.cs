using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class softwarepackagecurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "SoftwarePackage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoftwarePackage_CurrencyId",
                table: "SoftwarePackage",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwarePackage_Country_CurrencyId",
                table: "SoftwarePackage",
                column: "CurrencyId",
                principalTable: "Country",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftwarePackage_Country_CurrencyId",
                table: "SoftwarePackage");

            migrationBuilder.DropIndex(
                name: "IX_SoftwarePackage_CurrencyId",
                table: "SoftwarePackage");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "SoftwarePackage");
        }
    }
}
