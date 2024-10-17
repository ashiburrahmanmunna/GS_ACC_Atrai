using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class accountparentcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentAccountCategoryId",
                table: "AccountCategory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountCategory_ParentAccountCategoryId",
                table: "AccountCategory",
                column: "ParentAccountCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountCategory_AccountCategory_ParentAccountCategoryId",
                table: "AccountCategory",
                column: "ParentAccountCategoryId",
                principalTable: "AccountCategory",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountCategory_AccountCategory_ParentAccountCategoryId",
                table: "AccountCategory");

            migrationBuilder.DropIndex(
                name: "IX_AccountCategory_ParentAccountCategoryId",
                table: "AccountCategory");

            migrationBuilder.DropColumn(
                name: "ParentAccountCategoryId",
                table: "AccountCategory");
        }
    }
}
