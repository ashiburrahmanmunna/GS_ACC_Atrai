using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateBOMMaster2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Revision",
                table: "BOMMaster",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Revision",
                table: "BOMMaster");
        }
    }
}
