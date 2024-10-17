using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class salesrepresentative : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalesRepId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SalesRepId",
                table: "Sales",
                column: "SalesRepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Employee_SalesRepId",
                table: "Sales",
                column: "SalesRepId",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Employee_SalesRepId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_SalesRepId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SalesRepId",
                table: "Sales");
        }
    }
}
