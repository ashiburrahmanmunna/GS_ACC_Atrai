using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class shopnameengbng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShopName",
                table: "Shop",
                newName: "ShopNameEng");

            migrationBuilder.AddColumn<string>(
                name: "ShopNameBng",
                table: "Shop",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopNameBng",
                table: "Shop");

            migrationBuilder.RenameColumn(
                name: "ShopNameEng",
                table: "Shop",
                newName: "ShopName");
        }
    }
}
