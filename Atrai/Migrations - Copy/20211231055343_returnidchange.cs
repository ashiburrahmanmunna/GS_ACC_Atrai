using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class returnidchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesExchangeItems_SalesReturn_SalesExchangeId",
                table: "SalesExchangeItems");

            migrationBuilder.RenameColumn(
                name: "SalesExchangeId",
                table: "SalesExchangeItems",
                newName: "SalesReturnId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesExchangeItems_SalesExchangeId",
                table: "SalesExchangeItems",
                newName: "IX_SalesExchangeItems_SalesReturnId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesExchangeItems_SalesReturn_SalesReturnId",
                table: "SalesExchangeItems",
                column: "SalesReturnId",
                principalTable: "SalesReturn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesExchangeItems_SalesReturn_SalesReturnId",
                table: "SalesExchangeItems");

            migrationBuilder.RenameColumn(
                name: "SalesReturnId",
                table: "SalesExchangeItems",
                newName: "SalesExchangeId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesExchangeItems_SalesReturnId",
                table: "SalesExchangeItems",
                newName: "IX_SalesExchangeItems_SalesExchangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesExchangeItems_SalesReturn_SalesExchangeId",
                table: "SalesExchangeItems",
                column: "SalesExchangeId",
                principalTable: "SalesReturn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
