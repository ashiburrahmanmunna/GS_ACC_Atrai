using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class PurchaseandPurchaseItemsModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemsReturnStatus",
                table: "PurchaseItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReturnStatus",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemsReturnStatus",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "ReturnStatus",
                table: "Purchase");
        }
    }
}
