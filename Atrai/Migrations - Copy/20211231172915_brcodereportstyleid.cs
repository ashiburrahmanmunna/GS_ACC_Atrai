using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class brcodereportstyleid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarcodeReportStyleId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_BarcodeReportStyleId",
                table: "StoreSetting",
                column: "BarcodeReportStyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_ReportStyle_BarcodeReportStyleId",
                table: "StoreSetting",
                column: "BarcodeReportStyleId",
                principalTable: "ReportStyle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_ReportStyle_BarcodeReportStyleId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_BarcodeReportStyleId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "BarcodeReportStyleId",
                table: "StoreSetting");
        }
    }
}
