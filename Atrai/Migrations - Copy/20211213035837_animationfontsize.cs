using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class animationfontsize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TextMessageOneSize",
                table: "MobileTextAnimation",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextMessageThreeSize",
                table: "MobileTextAnimation",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextMessageTwoSize",
                table: "MobileTextAnimation",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeSize",
                table: "MobileTextAnimation",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TextMessageOneSize",
                table: "MobileTextAnimation");

            migrationBuilder.DropColumn(
                name: "TextMessageThreeSize",
                table: "MobileTextAnimation");

            migrationBuilder.DropColumn(
                name: "TextMessageTwoSize",
                table: "MobileTextAnimation");

            migrationBuilder.DropColumn(
                name: "TypeSize",
                table: "MobileTextAnimation");
        }
    }
}
