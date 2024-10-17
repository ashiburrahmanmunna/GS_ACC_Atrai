using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeColorANdSizeChild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SLNo",
                table: "SizeChild",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SLNo",
                table: "ColorChild",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SLNo",
                table: "SizeChild");

            migrationBuilder.DropColumn(
                name: "SLNo",
                table: "ColorChild");
        }
    }
}
