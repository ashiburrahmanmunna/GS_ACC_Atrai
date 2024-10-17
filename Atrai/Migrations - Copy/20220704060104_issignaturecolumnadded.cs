using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class issignaturecolumnadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSignature",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSignature",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSignature",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsSignature",
                table: "Company");
        }
    }
}
