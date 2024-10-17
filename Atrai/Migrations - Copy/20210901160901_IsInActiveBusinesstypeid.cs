using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class IsInActiveBusinesstypeid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInActive",
                table: "SubscriptionType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FirstParameter",
                table: "Menu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstValue",
                table: "Menu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInActive",
                table: "BusinessType",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInActive",
                table: "SubscriptionType");

            migrationBuilder.DropColumn(
                name: "FirstParameter",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "FirstValue",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "IsInActive",
                table: "BusinessType");
        }
    }
}
