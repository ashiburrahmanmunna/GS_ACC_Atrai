using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updateOrderAllocatiomasterTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalAmount",
                table: "OrderAllocationMaster",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalQuantity",
                table: "OrderAllocationMaster",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "OrderAllocationMaster",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "OrderAllocationMaster");

            migrationBuilder.DropColumn(
                name: "TotalQuantity",
                table: "OrderAllocationMaster");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "OrderAllocationMaster");
        }
    }
}
