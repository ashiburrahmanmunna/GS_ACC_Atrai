using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class brandname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandName",
                table: "Product");

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "BrandName",
                table: "Product",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
