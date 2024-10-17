using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class SalesandSalesItemsmodelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "SalesItems",
                newName: "ItemsReturnStatus");

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReturnStatus",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ReturnStatus",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "ItemsReturnStatus",
                table: "SalesItems",
                newName: "Status");
        }
    }
}
