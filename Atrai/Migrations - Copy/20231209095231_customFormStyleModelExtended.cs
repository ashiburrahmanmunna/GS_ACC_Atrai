using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class customFormStyleModelExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocTypeId",
                table: "CustomFormStyle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormStyle_DocTypeId",
                table: "CustomFormStyle",
                column: "DocTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormStyle_DocType_DocTypeId",
                table: "CustomFormStyle",
                column: "DocTypeId",
                principalTable: "DocType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormStyle_DocType_DocTypeId",
                table: "CustomFormStyle");

            migrationBuilder.DropIndex(
                name: "IX_CustomFormStyle_DocTypeId",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "DocTypeId",
                table: "CustomFormStyle");
        }
    }
}
