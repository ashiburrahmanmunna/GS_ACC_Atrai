using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImportCIdetailsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ExtraPercentage",
                table: "ImportCI_Details",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GrossQty",
                table: "ImportCI_Details",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraPercentage",
                table: "ImportCI_Details");

            migrationBuilder.DropColumn(
                name: "GrossQty",
                table: "ImportCI_Details");
        }
    }
}
