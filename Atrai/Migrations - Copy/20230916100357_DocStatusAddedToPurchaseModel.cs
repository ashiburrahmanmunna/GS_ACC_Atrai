using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class DocStatusAddedToPurchaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocStatusId",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_DocStatusId",
                table: "Purchase",
                column: "DocStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_DocStatus_DocStatusId",
                table: "Purchase",
                column: "DocStatusId",
                principalTable: "DocStatus",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_DocStatus_DocStatusId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_DocStatusId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "DocStatusId",
                table: "Purchase");
        }
    }
}
