using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class addSecondaryPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SecondaryPrice",
                table: "SalesItems",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SecondaryPrice",
                table: "PurchaseItems",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondaryPrice",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "SecondaryPrice",
                table: "PurchaseItems");
        }
    }
}
