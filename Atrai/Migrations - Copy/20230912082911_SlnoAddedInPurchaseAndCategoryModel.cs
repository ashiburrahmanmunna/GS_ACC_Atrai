using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class SlnoAddedInPurchaseAndCategoryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SLNo",
                table: "PurchaseItemsCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SLNo",
                table: "PurchaseItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SLNo",
                table: "PurchaseItemsCategory");

            migrationBuilder.DropColumn(
                name: "SLNo",
                table: "PurchaseItems");
        }
    }
}
