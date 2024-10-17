using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class fixeddiscountvalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFixedDiscountMainValue",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFixedDiscountRowValue",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "MaxDiscountMainValue",
                table: "StoreSetting",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaxDiscountRowValue",
                table: "StoreSetting",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFixedDiscountMainValue",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsFixedDiscountRowValue",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "MaxDiscountMainValue",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "MaxDiscountRowValue",
                table: "StoreSetting");
        }
    }
}
