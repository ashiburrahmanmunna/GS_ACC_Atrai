using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class doctypeinpurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocTypeId",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_DocTypeId",
                table: "Purchase",
                column: "DocTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_DocType_DocTypeId",
                table: "Purchase",
                column: "DocTypeId",
                principalTable: "DocType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_DocType_DocTypeId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_DocTypeId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "DocTypeId",
                table: "Purchase");
        }
    }
}
