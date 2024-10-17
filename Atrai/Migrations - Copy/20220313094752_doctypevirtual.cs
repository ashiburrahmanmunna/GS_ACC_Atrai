using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class doctypevirtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_InternetUser_DocTypeId",
                table: "Sales");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_DocType_DocTypeId",
                table: "Sales",
                column: "DocTypeId",
                principalTable: "DocType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_DocType_DocTypeId",
                table: "Sales");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_InternetUser_DocTypeId",
                table: "Sales",
                column: "DocTypeId",
                principalTable: "InternetUser",
                principalColumn: "Id");
        }
    }
}
