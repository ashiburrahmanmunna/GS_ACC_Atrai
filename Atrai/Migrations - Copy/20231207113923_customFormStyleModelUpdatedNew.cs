using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class customFormStyleModelUpdatedNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFitPrinted",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLetterHeadUsed",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFitPrinted",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsLetterHeadUsed",
                table: "CustomFormStyle");
        }
    }
}
