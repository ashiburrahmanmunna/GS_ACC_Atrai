using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class animationcolor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "MobileTextAnimation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextMessageOneColor",
                table: "MobileTextAnimation",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextMessageThreeColor",
                table: "MobileTextAnimation",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextMessageTwoColor",
                table: "MobileTextAnimation",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeColor",
                table: "MobileTextAnimation",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TextMessageOneColor",
                table: "MobileTextAnimation");

            migrationBuilder.DropColumn(
                name: "TextMessageThreeColor",
                table: "MobileTextAnimation");

            migrationBuilder.DropColumn(
                name: "TextMessageTwoColor",
                table: "MobileTextAnimation");

            migrationBuilder.DropColumn(
                name: "TypeColor",
                table: "MobileTextAnimation");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "MobileTextAnimation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
