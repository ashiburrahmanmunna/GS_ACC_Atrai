using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class removeisbasemenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isBaseMenu",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "isDashboard",
                table: "Menu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isBaseMenu",
                table: "Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDashboard",
                table: "Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
