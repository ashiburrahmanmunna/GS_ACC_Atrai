using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class productsearchandprintoption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsIndDiscount",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSalesDescription",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSerialSales",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PrintBrandName",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PrintModelName",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PrintProductCode",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PrintProductDescription",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PrintProductName",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PrintSizeName",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIndDiscount",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsSalesDescription",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsSerialSales",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "PrintBrandName",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "PrintModelName",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "PrintProductCode",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "PrintProductDescription",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "PrintProductName",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "PrintSizeName",
                table: "StoreSetting");
        }
    }
}
