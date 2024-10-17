using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class businesstypeidadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusinessTypeId",
                table: "AccountHead_SystemX",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountHead_SystemX_BusinessTypeId",
                table: "AccountHead_SystemX",
                column: "BusinessTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHead_SystemX_BusinessType_BusinessTypeId",
                table: "AccountHead_SystemX",
                column: "BusinessTypeId",
                principalTable: "BusinessType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountHead_SystemX_BusinessType_BusinessTypeId",
                table: "AccountHead_SystemX");

            migrationBuilder.DropIndex(
                name: "IX_AccountHead_SystemX_BusinessTypeId",
                table: "AccountHead_SystemX");

            migrationBuilder.DropColumn(
                name: "BusinessTypeId",
                table: "AccountHead_SystemX");
        }
    }
}
