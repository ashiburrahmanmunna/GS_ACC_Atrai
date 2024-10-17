using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_ReportStyle_ReportStyleId",
                table: "StoreSetting");

            migrationBuilder.RenameColumn(
                name: "ReportStyleId",
                table: "StoreSetting",
                newName: "SalesReportStyleId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreSetting_ReportStyleId",
                table: "StoreSetting",
                newName: "IX_StoreSetting_SalesReportStyleId");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseReportStyleId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxPer",
                table: "Category",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "isTaxExcluded",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_PurchaseReportStyleId",
                table: "StoreSetting",
                column: "PurchaseReportStyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_ReportStyle_PurchaseReportStyleId",
                table: "StoreSetting",
                column: "PurchaseReportStyleId",
                principalTable: "ReportStyle",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_ReportStyle_SalesReportStyleId",
                table: "StoreSetting",
                column: "SalesReportStyleId",
                principalTable: "ReportStyle",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_ReportStyle_PurchaseReportStyleId",
                table: "StoreSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_ReportStyle_SalesReportStyleId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_PurchaseReportStyleId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "PurchaseReportStyleId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "TaxPer",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "isTaxExcluded",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "SalesReportStyleId",
                table: "StoreSetting",
                newName: "ReportStyleId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreSetting_SalesReportStyleId",
                table: "StoreSetting",
                newName: "IX_StoreSetting_ReportStyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_ReportStyle_ReportStyleId",
                table: "StoreSetting",
                column: "ReportStyleId",
                principalTable: "ReportStyle",
                principalColumn: "Id");
        }
    }
}
