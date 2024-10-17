using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class PurchaseModelUpdatedByMahin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShipVia",
                table: "Purchase",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress",
                table: "Purchase",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipVia",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "ShippingAddress",
                table: "Purchase");
        }
    }
}
