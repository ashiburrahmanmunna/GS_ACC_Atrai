using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class colorshortnamesizeshortname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SizeShortName",
                table: "Size",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorShortName",
                table: "Color",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizeShortName",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "ColorShortName",
                table: "Color");
        }
    }
}
