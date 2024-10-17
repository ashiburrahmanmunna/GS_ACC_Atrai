using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class AccountHeadSystemupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountHead_SystemX_AccountHead_ParentId",
                table: "AccountHead_SystemX");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHead_SystemX_AccountHead_SystemX_ParentId",
                table: "AccountHead_SystemX",
                column: "ParentId",
                principalTable: "AccountHead_SystemX",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountHead_SystemX_AccountHead_SystemX_ParentId",
                table: "AccountHead_SystemX");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHead_SystemX_AccountHead_ParentId",
                table: "AccountHead_SystemX",
                column: "ParentId",
                principalTable: "AccountHead",
                principalColumn: "Id");
        }
    }
}
