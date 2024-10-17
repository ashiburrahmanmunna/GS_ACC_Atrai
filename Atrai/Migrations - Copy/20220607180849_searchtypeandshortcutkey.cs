using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class searchtypeandshortcutkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortCutKey",
                table: "StoreSetting",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isScanner",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortCutKey",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "isScanner",
                table: "StoreSetting");
        }
    }
}
