using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class ModifyDydashTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSystem",
                table: "DyDashBoard",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Isvisible",
                table: "DyDashBoard",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Oder",
                table: "DyDashBoard",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSystem",
                table: "DyDashBoard");

            migrationBuilder.DropColumn(
                name: "Isvisible",
                table: "DyDashBoard");

            migrationBuilder.DropColumn(
                name: "Oder",
                table: "DyDashBoard");
        }
    }
}
