using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class businesstypeidroleid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusinessTypeid",
                table: "MenuPermission",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermission_BusinessTypeid",
                table: "MenuPermission",
                column: "BusinessTypeid");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermission_BusinessType_BusinessTypeid",
                table: "MenuPermission",
                column: "BusinessTypeid",
                principalTable: "BusinessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermission_BusinessType_BusinessTypeid",
                table: "MenuPermission");

            migrationBuilder.DropIndex(
                name: "IX_MenuPermission_BusinessTypeid",
                table: "MenuPermission");

            migrationBuilder.DropColumn(
                name: "BusinessTypeid",
                table: "MenuPermission");
        }
    }
}
