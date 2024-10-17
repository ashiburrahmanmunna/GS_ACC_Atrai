using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class CustomFormStyleExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReminderEmailTemplateHolder",
                table: "CustomFormStyle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StandardEmailTemplateHolder",
                table: "CustomFormStyle",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReminderEmailTemplateHolder",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "StandardEmailTemplateHolder",
                table: "CustomFormStyle");
        }
    }
}
