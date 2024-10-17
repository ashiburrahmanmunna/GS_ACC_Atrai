using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class MasterLCDetailsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CMTPercentage",
                table: "COM_MasterLC_Details",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CMTTotalAmount",
                table: "COM_MasterLC_Details",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CMTUnitPrice",
                table: "COM_MasterLC_Details",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CMTPercentage",
                table: "COM_MasterLC_Details");

            migrationBuilder.DropColumn(
                name: "CMTTotalAmount",
                table: "COM_MasterLC_Details");

            migrationBuilder.DropColumn(
                name: "CMTUnitPrice",
                table: "COM_MasterLC_Details");
        }
    }
}
