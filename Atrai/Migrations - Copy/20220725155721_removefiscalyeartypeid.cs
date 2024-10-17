using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class removefiscalyeartypeid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_FiscalYearType_FiscalYearTypeId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_FiscalYearType_FiscalYearTypeId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_FiscalYearTypeId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_Company_FiscalYearTypeId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "FiscalYearTypeId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "FiscalYearTypeId",
                table: "Company");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FiscalYearTypeId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiscalYearTypeId",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_FiscalYearTypeId",
                table: "StoreSetting",
                column: "FiscalYearTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_FiscalYearTypeId",
                table: "Company",
                column: "FiscalYearTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_FiscalYearType_FiscalYearTypeId",
                table: "Company",
                column: "FiscalYearTypeId",
                principalTable: "FiscalYearType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_FiscalYearType_FiscalYearTypeId",
                table: "StoreSetting",
                column: "FiscalYearTypeId",
                principalTable: "FiscalYearType",
                principalColumn: "Id");
        }
    }
}
