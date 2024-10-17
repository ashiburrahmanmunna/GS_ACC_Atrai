using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class ModifyReportModelsTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "Reports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Reports",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Reports");
        }
    }
}
