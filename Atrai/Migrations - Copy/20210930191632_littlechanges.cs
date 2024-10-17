using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class littlechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_AccountHead_AccountPayTypeId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_AccountPayTypeId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "AccountPayTypeId",
                table: "Purchase");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountPayTypeId",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_AccountPayTypeId",
                table: "Purchase",
                column: "AccountPayTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_AccountHead_AccountPayTypeId",
                table: "Purchase",
                column: "AccountPayTypeId",
                principalTable: "AccountHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
