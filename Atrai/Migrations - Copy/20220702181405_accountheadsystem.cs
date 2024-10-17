using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class accountheadsystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountHead_SystemX_AccountCategory_AccountCategoryId",
                table: "AccountHead_SystemX");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountHead_SystemX_AccountHead_SystemX_ParentId",
                table: "AccountHead_SystemX");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountHead_SystemX_BusinessType_BusinessTypeId",
                table: "AccountHead_SystemX");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountHead_SystemX",
                table: "AccountHead_SystemX");

            migrationBuilder.RenameTable(
                name: "AccountHead_SystemX",
                newName: "AccountHead_System");

            migrationBuilder.RenameIndex(
                name: "IX_AccountHead_SystemX_ParentId",
                table: "AccountHead_System",
                newName: "IX_AccountHead_System_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountHead_SystemX_BusinessTypeId",
                table: "AccountHead_System",
                newName: "IX_AccountHead_System_BusinessTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountHead_SystemX_AccountCategoryId",
                table: "AccountHead_System",
                newName: "IX_AccountHead_System_AccountCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountHead_System",
                table: "AccountHead_System",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHead_System_AccountCategory_AccountCategoryId",
                table: "AccountHead_System",
                column: "AccountCategoryId",
                principalTable: "AccountCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHead_System_AccountHead_System_ParentId",
                table: "AccountHead_System",
                column: "ParentId",
                principalTable: "AccountHead_System",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHead_System_BusinessType_BusinessTypeId",
                table: "AccountHead_System",
                column: "BusinessTypeId",
                principalTable: "BusinessType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountHead_System_AccountCategory_AccountCategoryId",
                table: "AccountHead_System");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountHead_System_AccountHead_System_ParentId",
                table: "AccountHead_System");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountHead_System_BusinessType_BusinessTypeId",
                table: "AccountHead_System");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountHead_System",
                table: "AccountHead_System");

            migrationBuilder.RenameTable(
                name: "AccountHead_System",
                newName: "AccountHead_SystemX");

            migrationBuilder.RenameIndex(
                name: "IX_AccountHead_System_ParentId",
                table: "AccountHead_SystemX",
                newName: "IX_AccountHead_SystemX_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountHead_System_BusinessTypeId",
                table: "AccountHead_SystemX",
                newName: "IX_AccountHead_SystemX_BusinessTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountHead_System_AccountCategoryId",
                table: "AccountHead_SystemX",
                newName: "IX_AccountHead_SystemX_AccountCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountHead_SystemX",
                table: "AccountHead_SystemX",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHead_SystemX_AccountCategory_AccountCategoryId",
                table: "AccountHead_SystemX",
                column: "AccountCategoryId",
                principalTable: "AccountCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHead_SystemX_AccountHead_SystemX_ParentId",
                table: "AccountHead_SystemX",
                column: "ParentId",
                principalTable: "AccountHead_SystemX",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHead_SystemX_BusinessType_BusinessTypeId",
                table: "AccountHead_SystemX",
                column: "BusinessTypeId",
                principalTable: "BusinessType",
                principalColumn: "Id");
        }
    }
}
