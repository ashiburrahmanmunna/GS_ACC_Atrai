using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class salesrepinsalesreturn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalesRepId",
                table: "SalesReturn",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_SalesRepId",
                table: "SalesReturn",
                column: "SalesRepId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturn_Employee_SalesRepId",
                table: "SalesReturn",
                column: "SalesRepId",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturn_Employee_SalesRepId",
                table: "SalesReturn");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturn_SalesRepId",
                table: "SalesReturn");

            migrationBuilder.DropColumn(
                name: "SalesRepId",
                table: "SalesReturn");
        }
    }
}
