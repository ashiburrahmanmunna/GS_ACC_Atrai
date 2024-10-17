using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class addUnitIdInImportCI_Details : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "ImportCI_Details");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "ImportCI_Details",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Details_UnitId",
                table: "ImportCI_Details",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportCI_Details_Unit_UnitId",
                table: "ImportCI_Details",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportCI_Details_Unit_UnitId",
                table: "ImportCI_Details");

            migrationBuilder.DropIndex(
                name: "IX_ImportCI_Details_UnitId",
                table: "ImportCI_Details");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "ImportCI_Details");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "ImportCI_Details",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
