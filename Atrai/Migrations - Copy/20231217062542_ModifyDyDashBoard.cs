using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class ModifyDyDashBoard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalFilterTitle",
                table: "DyDashBoard",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grouptitle",
                table: "DyDashBoard",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimePriod",
                table: "DyDashBoard",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimePriodValue",
                table: "DyDashBoard",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalFilterTitle",
                table: "DyDashBoard");

            migrationBuilder.DropColumn(
                name: "Grouptitle",
                table: "DyDashBoard");

            migrationBuilder.DropColumn(
                name: "TimePriod",
                table: "DyDashBoard");

            migrationBuilder.DropColumn(
                name: "TimePriodValue",
                table: "DyDashBoard");
        }
    }
}
