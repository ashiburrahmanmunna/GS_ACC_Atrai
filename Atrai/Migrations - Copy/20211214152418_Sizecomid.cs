using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class Sizecomid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "Size",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "Color",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Size_ComId",
                table: "Size",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Color_ComId",
                table: "Color",
                column: "ComId");

            migrationBuilder.AddForeignKey(
                name: "FK_Color_Company_ComId",
                table: "Color",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Size_Company_ComId",
                table: "Size",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_Company_ComId",
                table: "Color");

            migrationBuilder.DropForeignKey(
                name: "FK_Size_Company_ComId",
                table: "Size");

            migrationBuilder.DropIndex(
                name: "IX_Size_ComId",
                table: "Size");

            migrationBuilder.DropIndex(
                name: "IX_Color_ComId",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Color");
        }
    }
}
