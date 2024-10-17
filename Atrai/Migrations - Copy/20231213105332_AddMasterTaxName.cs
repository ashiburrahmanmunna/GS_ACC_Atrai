using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class AddMasterTaxName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MasterTaxName",
                table: "PurchaseItemsCategory",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MasterTaxName",
                table: "PurchaseItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterTaxName",
                table: "PurchaseItemsCategory");

            migrationBuilder.DropColumn(
                name: "MasterTaxName",
                table: "PurchaseItems");
        }
    }
}
