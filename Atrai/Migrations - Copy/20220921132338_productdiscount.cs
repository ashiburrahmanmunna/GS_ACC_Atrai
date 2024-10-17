using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class productdiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OfferDiscountPer",
                table: "StoreSetting",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "isDiscountOffer",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductDiscountAmount",
                table: "Product",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductDiscountPer",
                table: "Product",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfferDiscountPer",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "isDiscountOffer",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ProductDiscountAmount",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductDiscountPer",
                table: "Product");
        }
    }
}
