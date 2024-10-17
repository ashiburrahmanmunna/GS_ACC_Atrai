using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class marketandshopcolumnadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShopType",
                table: "Shop",
                newName: "ShopTypeItemProduct");

            migrationBuilder.RenameColumn(
                name: "ShopAddress",
                table: "Shop",
                newName: "ShopBusinessAddressEng");

            migrationBuilder.AddColumn<string>(
                name: "HoldingNoBng",
                table: "Shop",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoldingNoEng",
                table: "Shop",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShopBusinessAddressBng",
                table: "Shop",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoldingNoBng",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "HoldingNoEng",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "ShopBusinessAddressBng",
                table: "Shop");

            migrationBuilder.RenameColumn(
                name: "ShopTypeItemProduct",
                table: "Shop",
                newName: "ShopType");

            migrationBuilder.RenameColumn(
                name: "ShopBusinessAddressEng",
                table: "Shop",
                newName: "ShopAddress");
        }
    }
}
