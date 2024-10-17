using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class addSalesParentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SalesItemReturnId",
                table: "SalesItems",
                newName: "SalesItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_SalesItemsId",
                table: "SalesItems",
                column: "SalesItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesItems_SalesItems_SalesItemsId",
                table: "SalesItems",
                column: "SalesItemsId",
                principalTable: "SalesItems",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesItems_SalesItems_SalesItemsId",
                table: "SalesItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesItems_SalesItemsId",
                table: "SalesItems");

            migrationBuilder.RenameColumn(
                name: "SalesItemsId",
                table: "SalesItems",
                newName: "SalesItemReturnId");
        }
    }
}
