using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class Gatepassisposted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isPosted",
                table: "GatePass",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPosted",
                table: "GatePass");
        }
    }
}
