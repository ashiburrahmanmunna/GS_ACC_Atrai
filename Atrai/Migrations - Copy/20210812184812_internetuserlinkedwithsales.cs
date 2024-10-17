using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class internetuserlinkedwithsales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InternetUserId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_InternetUserId",
                table: "Sales",
                column: "InternetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_InternetUser_InternetUserId",
                table: "Sales",
                column: "InternetUserId",
                principalTable: "InternetUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_InternetUser_InternetUserId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_InternetUserId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "InternetUserId",
                table: "Sales");
        }
    }
}
