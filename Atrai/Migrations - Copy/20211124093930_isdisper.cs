using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class isdisper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChkPer",
                table: "Sales",
                newName: "isDisPer");

            migrationBuilder.AddColumn<bool>(
                name: "isDisPerRow",
                table: "SalesItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDisPerRow",
                table: "SalesItems");

            migrationBuilder.RenameColumn(
                name: "isDisPer",
                table: "Sales",
                newName: "ChkPer");
        }
    }
}
