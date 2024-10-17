using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class shopcolumnadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShopOwner",
                table: "Shop",
                newName: "ShopOwnerEng");

            migrationBuilder.AddColumn<string>(
                name: "ShopOwnerBng",
                table: "Shop",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardNo",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopOwnerBng",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "CardNo",
                table: "Member");

            migrationBuilder.RenameColumn(
                name: "ShopOwnerEng",
                table: "Shop",
                newName: "ShopOwner");
        }
    }
}
